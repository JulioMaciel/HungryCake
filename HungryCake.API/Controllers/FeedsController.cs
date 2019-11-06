using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using HtmlAgilityPack;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Dtos.Feed;
using HungryCake.API.Helpers;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;

namespace HungryCake.API.Controllers
{
    [Route("api/feeds/")]
    // [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly ICakeRepository _repo;
        private readonly IMapper _mapper;

        public FeedsController(ICakeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        
        [HttpPost("rss/add")]
        public async Task<IActionResult> Add(FeedRssAddDto dto)
        {
            // if (await _repo.ca ..UserExists(userForRegisterDto.Username))
            //     return BadRequest("Username already exists");

            var rssToCreate = _mapper.Map<FeedRss>(dto);

            _repo.Add<FeedRss>(rssToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Creating the rss failed on save");
        }

        [HttpGet("rss")]
        public async Task<IActionResult> PreviewRss([FromQuery(Name="RssUrl")] string rssUrl)
        {
            var feed = await RssHelper.GetNewsFeed(rssUrl);

            // var response = new RssPreviewResponseDto() {
            //     FeedList = feed
            // };

            return Ok(feed);
        }

        [HttpGet("rss/description")]
        public async Task<IActionResult> ImportRssDescription([FromQuery(Name="url")] string url)
        {
            var desc = string.Empty;

            using(var web = new WebClient()) 
            {
                web.Headers.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                var uri = new Uri(url);
                var source = await web.DownloadStringTaskAsync(uri);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(source);
                var mdnode = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='description']");
                if (mdnode != null)
                {
                    HtmlAttribute descrip;

                    descrip = mdnode.Attributes["content"];
                    desc = descrip.Value;
                } else {
                    mdnode = htmlDoc.DocumentNode.SelectSingleNode("//meta[@property='og:description']");
                    if (mdnode != null)
                    {
                        HtmlAttribute descrip;

                        descrip = mdnode.Attributes["content"];
                        desc = descrip.Value;
                    }
                }
            }

            var response = new SiteDescriptionDto() {
                Description = desc
            };  

            return Ok(response);
        }

        [HttpPut("rss/{id}")]
        public async Task<IActionResult> UpdateRss(int id, FeedRssEditDto dto)
        {
            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();

            var rssFromRepo = await _repo.GetFeedRss(id);

            _mapper.Map(dto, rssFromRepo);

            var webClient = new WebClient();            
            rssFromRepo.Icon = webClient.DownloadData(dto.NewIconPath);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating category {id} failed to save");
        }

        [HttpGet("rss/{id}")]
        public async Task<IActionResult> GetRss(int id) 
        {
            var rss = await _repo.GetFeedRss(id);

            return Ok(rss);
        }

        [HttpGet("rss/list")]
        public async Task<IActionResult> GetRssList() 
        {
            var list = await _repo.GetRssList();

            return Ok(list);
        }

        [HttpGet("rss/icon")]
        public async Task<IActionResult> ImportIcon([FromQuery(Name="url")] string url)
        {
            var favicon = string.Empty;

            using(var web = new WebClient()) 
            {
                web.Headers.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                var uri = new Uri(url);
                var source = await web.DownloadStringTaskAsync(uri);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(source);
                
                var el = htmlDoc.DocumentNode.SelectSingleNode("/html/head/link[@rel='icon' and @href]");
                if (el != null)
                {
                    favicon = el.Attributes["href"].Value;
                }
            }

            var response = new SiteIconDto() {
                Icon = favicon
            };  

            return Ok(response);
        }

    }
}
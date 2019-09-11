using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Dtos.Feed;
using HungryCake.API.Helpers;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;

namespace HungryCake.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
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
        
        [HttpPost("add")]
        public async Task<IActionResult> Add(FeedRssAddDto dto)
        {
            // if (await _repo.ca ..UserExists(userForRegisterDto.Username))
            //     return BadRequest("Username already exists");

            var rssToCreate = _mapper.Map<FeedRss>(dto);

            rssToCreate.Category = await _repo.GetCategory(dto.CategoryId);
            rssToCreate.Creator = await _repo.GetUser(dto.CreatorId);

            _repo.Add<FeedRss>(rssToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Creating the rss failed on save");
        }

        [HttpGet]
        public async Task<IActionResult> PreviewRss([FromQuery(Name="RssUrl")] string rssUrl)
        {
            var feed = await RssHelper.GetNewsFeed(rssUrl);

            var response = new RssPreviewResponseDto() {
                FeedList = feed
            };

            return Ok(feed);
        }

    }
}
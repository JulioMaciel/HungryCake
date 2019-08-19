using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Helpers;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HungryCake.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly ICakeRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public FeedsController(ICakeRepository repo, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeed(int userId, FeedAddDto feedCreateDto)
        {
            var sender = await _repo.GetUser(userId.ToString());

            if (sender.Id != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            feedCreateDto.Creator.Id = userId.ToString();

            var feed = _mapper.Map<Feed>(feedCreateDto);

            _repo.Add(feed);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Creating the feed failed on save");
        }

        [HttpGet]
        public async Task<IActionResult> GetFeeds([FromQuery]FeedParams feedParams)
        {
            var feeds = await _repo.GetFeeds(feedParams);

            var feedsToReturn = _mapper.Map<IEnumerable<FeedListDto>>(feeds);

            Response.AddPagination(feeds.CurrentPage, feeds.PageSize, feeds.TotalCount, feeds.TotalPages);

            return Ok(feedsToReturn);
        }

        [HttpGet("{id}", Name = "GetFeed")]
        public async Task<IActionResult> GetFeed(int id)
        {
            var feed = await _repo.GetFeed(id.ToString());

            var feedToReturn = _mapper.Map<FeedDetailDto>(feed);

            return Ok(feedToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeed(int id)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var feedFromRepo = await _repo.GetFeed(id.ToString());

            // _mapper.Map(feedForUpdateDto, feedFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating feed {id} failed to save");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteFeed(int id)
        {
            var feedFromRepo = await _repo.GetFeed(id.ToString());

            _repo.Delete(feedFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error deleting the feed");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeactiveFeed(int id)
        {
            var feedFromRepo = await _repo.GetFeed(id.ToString());

            feedFromRepo.IsActive = false;

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error deactivating the feed");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ActivateFeed(int id)
        {
            var feedFromRepo = await _repo.GetFeed(id.ToString());

            feedFromRepo.IsActive = true;

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error activating the feed");
        }

        [HttpPost]
        public async Task<IActionResult> SelectFeeds(int userId, FeedsSelectDto feedSelectDto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            // var selectedFeeds =  new List<Feed>();

            foreach (var feedId in feedSelectDto.SelectedFeedIds)
            {
                var feedFromRepo = await _repo.GetFeed(feedId.ToString());

                var userFeed = new UserFeed(); // (user, feedFromRepo)
                userFeed.User = user;
                userFeed.Feed = feedFromRepo;

                if (!user.UserFeeds.Contains(userFeed))
                    user.UserFeeds.Add(userFeed);
                // selectedFeeds.Add(feedFromRepo);
            }

            var removedFeeds =  user.UserFeeds.Where(f => !feedSelectDto.SelectedFeedIds.Contains(f.FeedId));

            foreach (var removedFeed in removedFeeds)
            {
                user.UserFeeds.Remove(removedFeed);
            }

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error linking the user to the feeds");
        }

    }
}
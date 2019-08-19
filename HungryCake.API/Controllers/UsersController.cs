using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HungryCake.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICakeRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(ICakeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]UserParams userParams)
        {
            // var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // var userFromRepo = await _repo.GetUser(currentUserId);
            // userParams.ItemId = currentUserId;

            var users = await _repo.GetUsers(userParams);

            var usersToReturn = _mapper.Map<IEnumerable<UserListDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id.ToString());

            var userToReturn = _mapper.Map<UserDetailDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserEditDto userForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id.ToString());

            _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed to save");
        }
        
    }
}
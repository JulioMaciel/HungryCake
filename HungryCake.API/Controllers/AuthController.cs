using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HungryCake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ICakeRepository _cakeRepo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config, ICakeRepository cakeRepo)
        {
            _config = config;
            _repo = repo;
            _cakeRepo = cakeRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserAddDto userForRegisterDto)
        {
            userForRegisterDto.Email = userForRegisterDto.Email;

            if (await _repo.UserExists(userForRegisterDto.Email))
                return BadRequest("Email already exists");

            var userToCreate = new User
            {
                Email = userForRegisterDto.Email
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201); // brb
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Email, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Email, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userGrids = await _cakeRepo.GetUserGrids(userFromRepo.Id);
            var userGridsDto = new List<GridLogin>();
            
            foreach (var grid in userGrids) 
            {
                var dto = new GridLogin(grid.Id, grid.Name);
                userGridsDto.Add(dto);
            }

            return Ok(new {
                token = tokenHandler.WriteToken(token),
                user = userFromRepo,
                userGrids = userGridsDto
            });
        }
    }
}
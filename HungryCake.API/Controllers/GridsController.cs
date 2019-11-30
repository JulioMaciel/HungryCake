using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HungryCake.API.Controllers
{
    [Route("api/grids/")]
    [ApiController]
    public class GridsController : ControllerBase
    {
        private readonly ICakeRepository _repo;
        private readonly IMapper _mapper;
        public GridsController(ICakeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("add/{userId}")]
        public async Task<IActionResult> AddGrid(int userId)
        {
            var gridToCreate = new Grid(userId);

            // var gridToCreate = _mapper.Map<Grid>(dto);

            _repo.Add<Grid>(gridToCreate);

            if (await _repo.SaveAll())
            {
                return Ok(gridToCreate.Id);
            }

            throw new Exception("Creating the grid failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrid(int id, GridEditDto dto)
        {
            var gridFromRepo = await _repo.GetGrid(id);

            _mapper.Map(dto, gridFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating grid {id} failed to save");
        }

        [HttpGet("{gridId}")]
        public async Task<IActionResult> LoadGrid(int gridId) 
        {
            var grid = await _repo.GetGrid(gridId);
            grid.Columns = await _repo.GetColumnsFromGrid(gridId);            

            return Ok(grid);
        }

        // [HttpGet("user/{id}")]
        // public async Task<IActionResult> GetGridsFromUser(int userId)
        // {
        //     var grids = await _repo.GetGridsFromUser(userId);
        //     var usersToReturn = _mapper.Map<IEnumerable<GridEditDto>>(grids);

        //     return Ok(usersToReturn);
        // }
    }
}
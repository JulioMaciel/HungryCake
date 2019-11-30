using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HungryCake.API.Controllers
{
    [Route("api/columns/")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly ICakeRepository _repo;
        private readonly IMapper _mapper;
        public ColumnsController(ICakeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddColumn(ColumnAddDto dto)
        {
            var columnToCreate = _mapper.Map<Column>(dto);

            _repo.Add<Column>(columnToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Creating the column failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColumn(int id, ColumnEditDto dto)
        {
            var columnFromRepo = await _repo.GetColumn(id);

            _mapper.Map(dto, columnFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating column {id} failed to save");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HungryCake.API.Data;
using HungryCake.API.Dtos;
using HungryCake.API.Helpers;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HungryCake.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/categories/")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICakeRepository _repo;
        private readonly IMapper _mapper;

        public CategoriesController(ICakeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _repo.GetCategories();

            var catogiesReturn = _mapper.Map<IEnumerable<CategoryListDto>>(categories);

            return Ok(catogiesReturn);
        }

        // private async Task<IActionResult> GetCategory(int id)
        // {
        //     var catFromRepo = await _repo.GetCategory(id);

        //     if (catFromRepo == null)
        //         return NotFound();

        //     return Ok(catFromRepo);
        // }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryAddDto dto)
        {
            // if (await _repo.ca ..UserExists(userForRegisterDto.Username))
            //     return BadRequest("Username already exists");

            var catToCreate = _mapper.Map<Category>(dto);

            _repo.Add<Category>(catToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Creating the category failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _repo.GetCategory(id);

            var catChildren = _repo.GetCategories().Result
                                .Where(c => c.ParentId == cat.Id);

            var modifiedChildrenIds = catChildren.Select(c => c.Id);

            var uncategorizedCat = _repo.GetCategories().Result
                                    .FirstOrDefault(c => c.English == "Uncategorized");

            foreach (var child in catChildren)
            {
                child.ParentId = uncategorizedCat.Id;
            }

            _repo.Delete<Category>(cat);

            if (await _repo.SaveAll())
            {
                return Ok(modifiedChildrenIds);
            }
            
            return BadRequest("Failed to delete this category");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryEditDto dto)
        {
            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();

            var catFromRepo = await _repo.GetCategory(id);

            _mapper.Map(dto, catFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating category {id} failed to save");
        }
    }
}

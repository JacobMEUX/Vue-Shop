using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET api/category
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            return await _categoryService.GetAll();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            CategoryDTO categoryDTO = await _categoryService.GetByID(id);
            if (categoryDTO == null)
            {
                return NotFound();
            }
            return categoryDTO;
        }


        // POST api/category
        [HttpPost]
        public async Task<IActionResult> Post(CategoryDTO categoryDTO)
        {
            bool result = await _categoryService.Create(categoryDTO);
            if (result == false)
            {
                return StatusCode(400);
            }
            return StatusCode(201);

        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId)
            {
                return BadRequest();
            }

            await _categoryService.Update(categoryDTO);


            return NoContent();
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CategoryDTO categoryDTO = await _categoryService.GetByID(id);

            if (categoryDTO == null)
            {
                return NotFound();
            }
            await _categoryService.Remove(categoryDTO);

            return NoContent();
        }
    }
}

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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        // GET api/brand
        [HttpGet]
        public async Task<ActionResult<List<BrandDTO>>> Get()
        {
            return await _brandService.GetAll();
        }

        // GET api/brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> Get(int id)
        {
            BrandDTO brandDTO = await _brandService.GetByID(id);
            if (brandDTO == null)
            {
                return NotFound();
            }
            return brandDTO;
        }


        // POST api/brand
        [HttpPost]
        public async Task<IActionResult> Post(BrandDTO brandDTO)
        {
            bool result = await _brandService.Create(brandDTO);
            if (result == false)
            {
                return StatusCode(400);
            }
            return StatusCode(201);

        }

        // PUT api/brand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BrandDTO brandDTO)
        {
            if (id != brandDTO.BrandId)
            {
                return BadRequest();
            }

            await _brandService.Update(brandDTO);


            return NoContent();
        }

        // DELETE api/brand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            BrandDTO brandDTO = await _brandService.GetByID(id);

            if (brandDTO == null)
            {
                return NotFound();
            }
            await _brandService.Remove(brandDTO);

            return NoContent();
        }
    }
}

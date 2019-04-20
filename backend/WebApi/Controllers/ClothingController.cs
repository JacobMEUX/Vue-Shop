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
    public class ClothingController : ControllerBase
    {
        private readonly IClothingService _clothingService;
        //private readonly ICostumerService _costumerService;
        //private readonly ICategoryService _categoryService;
        //private readonly IBrandService _brandService;
        //private readonly IOrderService _orderService;
        //private readonly IOrderLineService _orderLineService;

        public ClothingController(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }
        // GET api/clothing
        [HttpGet]
        public async Task<ActionResult<List<ClothingDTO>>> Get()
        {
            return await _clothingService.GetAll();
        }

        // GET api/clothing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingDTO>> Get(int id)
        {
            ClothingDTO clothingDTO = await _clothingService.GetByID(id);
            if (clothingDTO == null)
            {
                return NotFound();
            }
            return clothingDTO;
        }

        // GET api/clothing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ClothingDTO>>> Get(SortFilterSearchOptionsDTO options)
        {
            List<ClothingDTO> clothingDTOs = await _clothingService.GetClothing(options);
            return clothingDTOs;
        }


        // POST api/clothing
        [HttpPost]
        public async Task<IActionResult> Post(ClothingDTO clothingDTO)
        {
            bool result = await _clothingService.Create(clothingDTO);
            if (result == false)
            {
                return StatusCode(400);
            }
            return StatusCode(201);

        }

        // PUT api/clothing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClothingDTO clothingDTO)
        {
            if (id != clothingDTO.ClothingId)
            {
                return BadRequest();
            }

            await _clothingService.Update(clothingDTO);


            return NoContent();
        }

        // DELETE api/clothing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ClothingDTO clothingDTO = await _clothingService.GetByID(id);

            if (clothingDTO == null)
            {
                return NotFound();
            }
            await _clothingService.Remove(clothingDTO);

            return NoContent();
        }
    }
}

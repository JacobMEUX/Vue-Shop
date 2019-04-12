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
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CostumerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }
        // GET api/costumer
        [HttpGet]
        public async Task<ActionResult<List<CostumerDTO>>> Get()
        {
            return await _costumerService.GetAll();
        }

        // GET api/costumer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CostumerDTO>> Get(int id)
        {
            CostumerDTO costumerDTO = await _costumerService.GetByID(id);
            if (costumerDTO == null)
            {
                return NotFound();
            }
            return costumerDTO;
        }


        // POST api/costumer
        [HttpPost]
        public async Task<IActionResult> Post(CostumerDTO costumerDTO)
        {
            bool result = await _costumerService.Create(costumerDTO);
            if (result == false)
            {
                return StatusCode(400);
            }
            return StatusCode(201);

        }

        // PUT api/costumer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CostumerDTO costumerDTO)
        {
            if (id != costumerDTO.CostumerId)
            {
                return BadRequest();
            }

            await _costumerService.Update(costumerDTO);


            return NoContent();
        }

        // DELETE api/costumer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CostumerDTO costumerDTO = await _costumerService.GetByID(id);

            if (costumerDTO == null)
            {
                return NotFound();
            }
            await _costumerService.Remove(costumerDTO);

            return NoContent();
        }
    }
}

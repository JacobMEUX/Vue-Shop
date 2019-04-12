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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET api/order
        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> Get()
        {
            return await _orderService.GetAll();
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO orderDTO = await _orderService.GetByID(id);
            if (orderDTO == null)
            {
                return NotFound();
            }
            return orderDTO;
        }


        // POST api/order
        [HttpPost]
        public async Task<IActionResult> Post(OrderDTO orderDTO)
        {
            bool result = await _orderService.Create(orderDTO);
            if (result == false)
            {
                return StatusCode(400);
            }
            return StatusCode(201);

        }

        // PUT api/order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderDTO orderDTO)
        {
            if (id != orderDTO.OrderId)
            {
                return BadRequest();
            }

            await _orderService.Update(orderDTO);


            return NoContent();
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OrderDTO orderDTO = await _orderService.GetByID(id);

            if (orderDTO == null)
            {
                return NotFound();
            }
            await _orderService.Remove(orderDTO);

            return NoContent();
        }
    }
}

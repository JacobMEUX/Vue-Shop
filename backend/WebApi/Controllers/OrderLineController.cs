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
    public class OrderLineController : ControllerBase
    {
        private readonly IOrderLineService _orderLineService;

        public OrderLineController(IOrderLineService orderLineService)
        {
            _orderLineService = orderLineService;
        }
        // GET api/orderLine
        [HttpGet]
        public async Task<ActionResult<List<OrderLineDTO>>> Get()
        {
            return await _orderLineService.GetAll();
        }

        // GET api/orderLine/5
        [HttpGet("{orderId}/{clothingId}")]
        public async Task<ActionResult<OrderLineDTO>> Get(int orderId, int clothingId)
        {
            OrderLineDTO orderLineDTO = await _orderLineService.GetOrderLine(orderId, clothingId);
            if (orderLineDTO == null)
            {
                return NotFound();
            }
            orderLineDTO.Order.OrderLines = null;
            return orderLineDTO;
        }


        // POST api/orderLine
        [HttpPost]
        public async Task<IActionResult> Post(OrderLineDTO orderLineDTO)
        {
            bool result = await _orderLineService.Create(orderLineDTO);
            if (result == false)
            {
                return StatusCode(400);
            }
            return StatusCode(201);

        }

        // PUT api/orderLine/5/2
        [HttpPut("{orderId}/{clothingId}")]
        public async Task<IActionResult> Put(int orderId, int clothingId, OrderLineDTO orderLineDTO)
        {
            if (orderId != orderLineDTO.FKOrderId || clothingId != orderLineDTO.FKClothingId)
            {
                return BadRequest();
            }

            await _orderLineService.Update(orderLineDTO);


            return NoContent();
        }

        // DELETE api/orderLine/5
        [HttpDelete("{orderId}/{clothingId}")]
        public async Task<IActionResult> Delete(int orderId, int clothingId)
        {
            OrderLineDTO orderLineDTO = await _orderLineService.GetOrderLine(orderId, clothingId);

            if (orderLineDTO == null)
            {
                return NotFound();
            }
            await _orderLineService.Remove(orderLineDTO);

            return NoContent();
        }
    }
}

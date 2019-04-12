using DataLayer.Entities;
using DataLayer.Interfaces;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly MappingService _mappingService;
        private readonly IOrderLineRepository _orderLineRepository;
        public OrderLineService(MappingService mappingService, IOrderLineRepository orderLineRepository)
        {
            _mappingService = mappingService;
            _orderLineRepository = orderLineRepository;
        }
        public async Task<bool> Create(OrderLineDTO orderLineDTO)
        {
            return await _orderLineRepository.Create(_mappingService._mapper.Map<OrderLine>(orderLineDTO));
        }

        public async Task<bool> DoesOrderLineExist(int orderId, int clothingId)
        {
            return await _orderLineRepository.DoesOrderLineExist(orderId, clothingId);
        }

        public async Task<List<OrderLineDTO>> GetAll()
        {
            return _mappingService._mapper.Map<List<OrderLineDTO>>(await _orderLineRepository.GetAll());
        }

        public async Task<OrderLineDTO> GetByID(int id)
        {
            return _mappingService._mapper.Map<OrderLineDTO>(await _orderLineRepository.GetByID(id));
        }

        public async Task<OrderLineDTO> GetOrderLine(int orderId, int clothingId)
        {
            return _mappingService._mapper.Map<OrderLineDTO>(await _orderLineRepository.GetOrderLine(orderId, clothingId));
        }

        public async Task<List<OrderLineDTO>> GetOrderLines(int? orderId, int? clothingId)
        {
            return _mappingService._mapper.Map<List<OrderLineDTO>>(await _orderLineRepository.GetOrderLines(orderId, clothingId));
        }

        public async Task<bool> Remove(OrderLineDTO orderLineDTO)
        {
            return await _orderLineRepository.Remove(_mappingService._mapper.Map<OrderLine>(orderLineDTO));
        }

        public async Task<bool> Update(OrderLineDTO orderLineDTO)
        {
            return await _orderLineRepository.Update(_mappingService._mapper.Map<OrderLine>(orderLineDTO));
        }
    }
}

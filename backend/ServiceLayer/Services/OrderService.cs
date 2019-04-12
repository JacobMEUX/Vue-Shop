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
    public class OrderService : IOrderService
    {
        private readonly MappingService _mappingService;
        private readonly IOrderRepository _orderRepository;
        public OrderService(MappingService mappingService, IOrderRepository orderRepository)
        {
            _mappingService = mappingService;
            _orderRepository = orderRepository;
        }
        public async Task<bool> Create(OrderDTO orderDTO)
        {
            return await _orderRepository.Create(_mappingService._mapper.Map<Order>(orderDTO));
        }

        public async Task<int?> CreateNewOrder(OrderDTO orderDTO)
        {
            return await _orderRepository.CreateNewOrder(_mappingService._mapper.Map<Order>(orderDTO));
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            return _mappingService._mapper.Map<List<OrderDTO>>(await _orderRepository.GetAll());
        }

        public async Task<OrderDTO> GetByID(int id)
        {
            return _mappingService._mapper.Map<OrderDTO>(await _orderRepository.GetByID(id));
        }

        public async Task<List<OrderDTO>> GetOrderByCostumerId(string id)
        {
            return _mappingService._mapper.Map<List<OrderDTO>>(await _orderRepository.GetOrderByCostumerId(id));
        }

        public async Task<bool> Remove(OrderDTO orderDTO)
        {
            return await _orderRepository.Remove(_mappingService._mapper.Map<Order>(orderDTO));
        }

        public async Task<bool> Update(OrderDTO orderDTO)
        {
            return await _orderRepository.Update(_mappingService._mapper.Map<Order>(orderDTO));
        }
    }
}

using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IOrderService : ICrudService<OrderDTO>
    {
        Task<int?> CreateNewOrder(OrderDTO orderDTO);
        Task<List<OrderDTO>> GetOrderByCostumerId(string id);
    }
}

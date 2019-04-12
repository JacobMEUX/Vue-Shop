using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IOrderLineService : ICrudService<OrderLineDTO>
    {
        Task<bool> DoesOrderLineExist(int orderId, int clothingId);
        Task<List<OrderLineDTO>> GetOrderLines(int? orderId, int? clothingId);

        Task<OrderLineDTO> GetOrderLine(int orderId, int clothingId);
    }
}

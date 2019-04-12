using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IOrderLineRepository : ICrudRepository<OrderLine>
    {
        Task<List<OrderLine>> GetOrderLines(int? orderId, int? clothingId);
        Task<bool> DoesOrderLineExist(int orderId, int clothingId);
        Task<OrderLine> GetOrderLine(int orderId, int clothingId);
    }
}

using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IOrderRepository : ICrudRepository<Order>
    {
        Task<int?> CreateNewOrder(Order order);
        Task<List<Order>> GetOrderByCostumerId(string id);
    }
}

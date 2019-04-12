using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderRepository : LogRepository, IOrderRepository
    {
        private readonly ShopContext _dbContext;
        public OrderRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Create(Order input)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> CreateNewOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully created a new order");
                return order.OrderId;
            }
            catch (Exception e)
            {
                LogError("Failed to create a new order", e);
                return null;
            }

        }


        public async Task<List<Order>> GetAll()
        {
            var query = _dbContext.Orders.AsNoTracking();

            try
            {
                List<Order> orders = await query.ToListAsync();
                LogInformation("Successfully fetched a list of orders");
                return orders;
            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of orders", e);
                return null;
            }

        }

        public async Task<Order> GetByID(int id)
        {

            var query = _dbContext.Orders.AsNoTracking();

            try
            {
                Order order = await query.SingleAsync(o => o.OrderId == id);
                LogInformation($"Successfully fetched a order with the ID: {id}");
                return order;

            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a order with the ID: {id}", e);
                return null;
            }
        }

        public async Task<List<Order>> GetOrderByCostumerId(string id)
        {
            var query = _dbContext.Orders
                    .AsNoTracking()
                    .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Clothing)
                    .ThenInclude(o => o.Image)
                    .Where(o => o.FKCostumerId == id);
            try
            {
                List<Order> orders = await query.ToListAsync();
                LogInformation($"Successfully fetched a order with the ID: {id}");
                return orders;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a order with the ID: {id}", e);
                return null;
            }
        }

        public async Task<bool> Remove(Order order)
        {
            try
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully removed a order");
                return true;


            }
            catch (Exception e)
            {
                LogError("Failed to remove a order", e);
                return false;
            }

        }

        public async Task<bool> Update(Order order)
        {
            try
            {
                _dbContext.Orders.Attach(order);
                _dbContext.Entry(order).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully updated a order");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to update a order", e);
                return false;
            }

        }
    }
}

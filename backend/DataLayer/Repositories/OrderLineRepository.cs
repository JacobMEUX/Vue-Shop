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
    public class OrderLineRepository : LogRepository, IOrderLineRepository
    {
        private readonly ShopContext _dbContext;
        public OrderLineRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(OrderLine orderLine)
        {
            try
            {
                _dbContext.OrderLines.Add(orderLine);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully created a new orderLine");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to create a new orderLine", e);
                return false;
            }

        }

        public async Task<bool> DoesOrderLineExist(int orderId, int clothingId)
        {
            var query = _dbContext.OrderLines
                .AsNoTracking()
                .Where(o =>
                o.FKOrderId == orderId &&
                o.FKClothingId == clothingId);
            try
            {
                int count = await query.CountAsync();
                LogInformation("Successfully validated an orderLine");
                return (count == 1) ? true : false;

            }
            catch (Exception e)
            {
                LogError("Failed to validate an orderLine", e);
                return false;
            }


        }

        public async Task<List<OrderLine>> GetAll()
        {
            var query = _dbContext.OrderLines
                      .Include(o => o.Clothing)
                      .Include(o => o.Order)
                      .AsNoTracking();
            try
            {
                List<OrderLine> orderLines = await query.ToListAsync();
                LogInformation("Successfully fetched a list of orderLines");
                return orderLines;
            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of orderLines", e);
                return null;
            }

        }

        public async Task<OrderLine> GetByID(int id)
        {
            var query = _dbContext.OrderLines
                    .Include(o => o.Clothing)
                    .Include(o => o.Order)
                    .AsNoTracking();
            try
            {
                OrderLine orderLine = await query.SingleAsync(o => o.FKOrderId == id);
                LogInformation($"Successfully fetched a orderLine with the ID: {id}");
                return orderLine;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a orderLine with the ID: {id}", e);
                return null;
            }

        }

        public async Task<OrderLine> GetOrderLine(int orderId, int clothingId)
        {
            var query = _dbContext.OrderLines
                    .Include(o => o.Clothing)
                    .Include(o => o.Order)
                    .AsNoTracking();
            try
            {
                // TODO: MAKE user send 2 ID's
                OrderLine orderLine = await query.SingleAsync(o => o.FKOrderId == orderId && o.FKClothingId == clothingId);
                LogInformation($"Successfully fetched a orderLine with the OrderId: {orderId} and ClothingId: {clothingId}");
                return orderLine;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a orderLine with the OrderId: {orderId} and ClothingId: {clothingId}", e);
                return null;
            }
        }

        public async Task<List<OrderLine>> GetOrderLines(int? orderId, int? clothingId)
        {
            var query = _dbContext.OrderLines
                .Include(o => o.Clothing)
                .Include(o => o.Order)
                .AsNoTracking();

            query = (orderId != null) ? query.Where(o => o.FKOrderId == orderId) : query;

            query = (clothingId != null) ? query.Where(o => o.FKOrderId == clothingId) : query;

            try
            {
                List<OrderLine> orderLines = await query.ToListAsync();
                LogInformation("Successfully fetched a list of orderLines");
                return orderLines;

            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of orderLines", e);
                return null;
            }
        }

        public async Task<bool> Remove(OrderLine orderLine)
        {
            try
            {
                _dbContext.OrderLines.Remove(orderLine);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully removed a orderLine");
                return true;
            }
            catch (Exception e)
            {
                LogError("Failed to remove a orderLine", e);
                return false;
            }

        }

        public async Task<bool> Update(OrderLine orderLine)
        {
            try
            {
                _dbContext.OrderLines.Attach(orderLine);
                _dbContext.Entry(orderLine).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully updated a orderLine");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to update a orderLine", e);
                return false;
            }

        }
    }
}

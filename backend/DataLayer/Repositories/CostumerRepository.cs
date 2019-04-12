using DataLayer.Entities;
using DataLayer;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataLayer.Repositories
{
    public class CostumerRepository : LogRepository, ICostumerRepository
    {

        private readonly ShopContext _dbContext;
        public CostumerRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Costumer costumer)
        {
            try
            {
                _dbContext.Costumers.Add(costumer);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully created a new costumer");
                return true;
            }
            catch (Exception e)
            {
                LogError("Failed to create a new costumer", e);
                return false;
            }

        }


        public async Task<List<Costumer>> GetAll()
        {
            var query = _dbContext.Costumers.AsNoTracking();
            try
            {
                List<Costumer> costumers = await query.ToListAsync();
                LogInformation("Successfully fetched a list of costumers");
                return costumers;
            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of costumers", e);
                return null;
            }

        }

        public async Task<Costumer> GetByID(string id)
        {
            var query = _dbContext.Costumers.AsNoTracking();
            try
            {
                Costumer costumer = await query.SingleAsync(o => o.CostumerId == id);
                LogInformation($"Successfully fetched a costumer with the ID: {id}");
                return costumer;

            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a costumer with the ID: {id}", e);
                return null;
            }

        }

        public async Task<Costumer> GetByID(int id)
        {
            var query = _dbContext.Costumers.AsNoTracking();
            try
            {
                Costumer costumer = await query.SingleAsync(o => o.CostumerId == id.ToString());
                LogInformation($"Successfully fetched a costumer with the ID: {id}");
                return costumer;

            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a costumer with the ID: {id}", e);
                return null;
            }
        }

        public async Task<bool> Remove(Costumer costumer)
        {
            try
            {
                _dbContext.Costumers.Remove(costumer);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully removed a costumer");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to remove a costumer", e);
                return false;
            }

        }

        public async Task<bool> Update(Costumer costumer)
        {
            try
            {
                _dbContext.Costumers.Attach(costumer);
                _dbContext.Entry(costumer).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully updated a costumer");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to update a costumer", e);
                return false;
            }

        }
    }

}


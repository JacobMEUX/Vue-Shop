using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class BrandRepository : LogRepository, IBrandRepository
    {
        private readonly ShopContext _dbContext;
        public BrandRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Brand brand)
        {
            try
            {
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully created a new brand");
                return true;
            }
            catch (Exception e)
            {
                LogError("Failed to create a new brand", e);
                return false;
            }

        }


        public async Task<List<Brand>> GetAll()
        {
            var query = _dbContext.Brands.AsNoTracking();

            try
            {
                List<Brand> brand = await query.ToListAsync();
                LogInformation("Successfully fetched a list of brands");
                return brand;

            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of brands", e);
                return null;
            }
        }

        public async Task<Brand> GetByID(int id)
        {
            var query = _dbContext.Brands.AsNoTracking();
            try
            {
                Brand brand =  await query.SingleAsync(o => o.BrandId == id);
                LogInformation($"Successfully fetched a brand with the ID: {id}");
                return brand;
            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a brand with the ID: {id}", e);
                return null;
            }

        }

        public async Task<bool> Remove(Brand brand)
        {
            try
            {
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully removed a brand");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to remove a brand", e);
                return false;
            }

        }

        public async Task<bool> Update(Brand brand)
        {
            try
            {
                _dbContext.Brands.Attach(brand);
                _dbContext.Entry(brand).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully updated a brand");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to update a brand", e);
                return false;
            }

        }
    }
}

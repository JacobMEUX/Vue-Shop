using DataLayer.Entities;
using DataLayer.Entities.Enums;
using DataLayer.ExtentionMethods;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ClothingRepository : LogRepository, IClothingRepository
    {
        private readonly ShopContext _dbContext;
        public ClothingRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Clothing clothing)
        {
            try
            {
                _dbContext.Clothing.Add(clothing);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully created a new clothing");
                return true;
            }
            catch (Exception e)
            {
                LogError("Failed to create a new clothing", e);
                return false;
            }

        }


        public async Task<List<Clothing>> GetAll()
        {
            var query = _dbContext.Clothing
                    .Include(o => o.Brand)
                    .Include(o => o.Category)
                    .Include(o => o.Image)
                    .AsNoTracking();
            try
            {
                List<Clothing> clothing = await query.ToListAsync();
                LogInformation("Successfully fetched a list of clothing");
                return clothing;
            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of clothing", e);
                return null;
            }

        }

        public async Task<Clothing> GetByID(int id)
        {
            var query = _dbContext.Clothing
                    .Include(o => o.Brand)
                    .Include(o => o.Category)
                    .Include(o => o.Image)
                    .AsNoTracking();
            try
            {
                Clothing clothing = await query.SingleAsync(o => o.ClothingId == id);
                LogInformation($"Successfully fetched a clothing with the ID: {id}");
                return clothing;
                    

            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a clothing with the ID: {id}", e);
                return null;
            }

        }

        public async Task<List<Clothing>> GetClothing(SortFilterSearchOptions options)
        {
            var query = _dbContext.Clothing
                .Include(o => o.Brand)
                .Include(o => o.Category)
                .Include(o => o.Image)
                .AsNoTracking()
                .GenerateQuery(options);

            try
            {
                List<Clothing> clothing = await query.Skip((options.CurrentPage - 1) * options.PageSize).Take(options.PageSize).ToListAsync(); 
                LogInformation("Successfully fetched a list of clothing");
                return clothing;
            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of clothing", e);
                return null;
            }
        }


        public async Task<int> GetCount(SortFilterSearchOptions options)
        {

            var query = _dbContext.Clothing
                .AsNoTracking()
                .GenerateQuery(options);

            try
            {
                return await query.CountAsync();
            }
            catch (Exception e)
            {
                LogError("Failed to count a list of clothing", e);
                return 0;
            }
        }

        public async Task<bool> Remove(Clothing clothing)
        {
            try
            {
                _dbContext.Clothing.Remove(clothing);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully removed a clothing");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to remove a clothing", e);
                return false;
            }
        }

        public async Task<bool> Update(Clothing clothing)
        {
            try
            {
                _dbContext.Clothing.Attach(clothing);
                _dbContext.Entry(clothing).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully updated a clothing");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to update a clothing", e);
                return false;
            }

        }
    }
}

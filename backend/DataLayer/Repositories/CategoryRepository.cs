using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository : LogRepository, ICategoryRepository
    {
        private readonly ShopContext _dbContext;
        public CategoryRepository(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully created a new category");
                return true;
            }
            catch (Exception e)
            {
                LogError("Failed to create a new category", e);
                return false;
            }

 

        }


        public async Task<List<Category>> GetAll()
        {
            var query = _dbContext.Categories.AsNoTracking();
            try
            {
                List<Category> Categories = await query.ToListAsync();
                LogInformation("Successfully fetched a list of categories");
                return Categories;

            }
            catch (Exception e)
            {
                LogError("Failed to fetch a list of categories", e);
                return null;
            }

        }

        public async Task<Category> GetByID(int id)
        {
            var query = _dbContext.Categories.AsNoTracking();
            try
            {
                Category category = await query.SingleAsync(o => o.CategoryId == id);
                LogInformation($"Successfully fetched a category with the ID: {id}");
                return category;

            }
            catch (Exception e)
            {
                LogError($"Failed to fetch a category with the ID: {id}", e);
                return null;
            }

        }

        public async Task<bool> Remove(Category category)
        {
            try
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully removed a category");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to remove a category", e);
                return false;
            }

        }

        public async Task<bool> Update(Category category)
        {
            try
            {
                _dbContext.Categories.Attach(category);
                _dbContext.Entry(category).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                LogInformation("Successfully updated a category");
                return true;

            }
            catch (Exception e)
            {
                LogError("Failed to update a category", e);
                return false;
            }

        }
    }
}

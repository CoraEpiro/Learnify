using AppDomain.DTOs.Category;
using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LearnifyDbContext _context;

        public CategoryRepository(LearnifyDbContext context)
        {
            _context = context;
        }

        public async Task<string> DeleteCategory(string categoryId)
        {
            var existingCategory = await _context.Categories.FindAsync(categoryId);

            if (existingCategory is null)
                return null;

            existingCategory.isDeleted = true;

            _context.Categories.Update(existingCategory);

            await _context.SaveChangesAsync();

            return categoryId;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return _context.Categories.ToList();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<string> InsertCategory(Category category)
        {
            
            var inserted = _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return inserted.Entity.Id;
        }

        public async Task<string> UpdateCategory(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);

            if (existingCategory is null)           
                return null;
            
            category.UseCount = existingCategory.UseCount;

            _context.Entry(existingCategory).CurrentValues.SetValues(category);

            await _context.SaveChangesAsync();

            return category.Id;
        }

        public async Task<int> UpdateUseCount(string categoryId)
        {
            var existingCategory = await _context.Categories.FindAsync(categoryId);

            if (existingCategory is null)
                return 0;

            existingCategory.UseCount++;

            _context.Categories.Update(existingCategory);

            await _context.SaveChangesAsync();

            return existingCategory.UseCount;
        }
    }
}
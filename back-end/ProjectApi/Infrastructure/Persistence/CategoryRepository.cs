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

        public Task<string> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

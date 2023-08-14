using AppDomain.Entities.TagBaseRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategoryById(string id);
        Task<string> InsertCategory(Category category);
        Task<string> UpdateCategory(Category category);
    }
}

using AppDomain.Entities.TagBaseRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Interfaces;

public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves a list of all categories asynchronously.
    /// </summary>
    /// <returns>A list of <see cref="Category"/> objects.</returns>
    Task<List<Category>> GetAllCategory();

    /// <summary>
    /// Retrieves a category by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <returns>The <see cref="Category"/> object.</returns>
    Task<Category> GetCategoryById(string id);

    /// <summary>
    /// Inserts a new category asynchronously and returns the inserted category ID.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> object to insert.</param>
    /// <returns>The inserted category ID.</returns>
    Task<string> InsertCategory(Category category);

    /// <summary>
    /// Updates an existing category asynchronously and returns a status message.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> object to update.</param>
    /// <returns>A status message indicating the result of the update operation.</returns>
    Task<string> UpdateCategory(Category category);

    /// <summary>
    /// Deletes a category by its ID asynchronously and returns a status message.
    /// </summary>
    /// <param name="categoryId">The ID of the category to delete.</param>
    /// <returns>A status message indicating the result of the delete operation.</returns>
    Task<string> DeleteCategory(string categoryId);

    /// <summary>
    /// Updates the use count of a category asynchronously and returns the updated count.
    /// </summary>
    /// <param name="categoryId">The ID of the category to update the use count for.</param>
    /// <returns>The updated use count value.</returns>
    Task<int> UpdateUseCount(string categoryId);
}
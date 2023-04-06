using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICategoryRepository
{
    Task<PagedList<Category>> GetCategoriesAsync(CategoryParameters parameters, bool trackChanges);
    void CreateCategory(Category category);
    Task<Category?> GetCategoryByIdAsync(Guid id, bool trackChanges);
    void DeleteCategory(Category category);
}
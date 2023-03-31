using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICategoryImageRepository
{
    Task<PagedList<CategoryImage>> GetCategoryImagesAsync(CategoryImageParameters parameters,
        bool trackChanges);

    Task<PagedList<CategoryImage>> GetCategoryImagesByCategoryAsync(Guid categoryId, CategoryImageParameters parameters,
        bool trackChanges);

    Task<CategoryImage> GetCategoryImageByIdAsync(Guid id, bool trackChanges);
    void CreateCategoryImage(Guid categoryId, CategoryImage categoryImage);
    void DeleteCategoryImage(CategoryImage categoryImage);
}
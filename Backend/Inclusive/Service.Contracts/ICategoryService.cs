using Shared;
using Shared.DataTransferObjects.CategoryDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetCategoriesAsync(CategoryParameters parameters,
        bool trackChanges);

    Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges);
    Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category);
    Task DeleteCategoryAsync(Guid id, bool trackChanges);
    Task UpdateCategoryAsync(Guid id, CategoryForUpdateDto category, bool trackChanges);
}
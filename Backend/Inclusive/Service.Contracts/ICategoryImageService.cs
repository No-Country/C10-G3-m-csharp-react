using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICategoryImageService
{
    Task<(IEnumerable<CategoryImageDto> categoryImages, MetaData metaData)> GetCategoryImagesAsync(
        CategoryImageParameters parameters,
        bool trackChanges);

    Task<(IEnumerable<CategoryImageDto> categoryImages, MetaData metaData)> GetCategoryImagesByCategoryAsync(
        Guid categoryId, CategoryImageParameters parameters, bool trackChanges);

    Task<CategoryImageDto> GetCategoryImageByIdAsync(Guid id, bool trackChanges);

    Task<CategoryImageDto> CreateCategoryImageAsync(Guid categoryId, CategoryImageForCreationDto categoryImage,
        bool trackChanges);

    Task DeleteCategoryImageAsync(Guid id, bool trackChanges);

    Task UpdateCategoryImageAsync(Guid categoryId, Guid id, CategoryImageForUpdateDto categoryImage,
        bool categoryTrackChanges, bool trackChanges);
}
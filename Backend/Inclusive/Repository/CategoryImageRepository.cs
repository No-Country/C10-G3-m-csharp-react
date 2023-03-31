using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class CategoryImageRepository : RepositoryBase<CategoryImage>,
    ICategoryImageRepository
{
    public CategoryImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<CategoryImage>> GetCategoryImagesAsync(CategoryImageParameters parameters,
        bool trackChanges)
    {
        var categoryImages = await FindAll(trackChanges)
            .OrderBy(ci => ci.Id)
            .ToListAsync();

        return PagedList<CategoryImage>.ToPagedList(categoryImages,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<PagedList<CategoryImage>> GetCategoryImagesByCategoryAsync(Guid categoryId,
        CategoryImageParameters parameters,
        bool trackChanges)
    {
        var categoryImages =
            await FindByCondition(ci => ci.CategoryId.Equals(categoryId),
                    trackChanges)
                .OrderBy(ci => ci.Id)
                .ToListAsync();

        return PagedList<CategoryImage>.ToPagedList(categoryImages,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<CategoryImage> GetCategoryImageByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(ci => ci.Id.Equals(id),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateCategoryImage(Guid categoryId, CategoryImage categoryImage)
    {
        categoryImage.CategoryId = categoryId;
        Create(categoryImage);
    }

    public void DeleteCategoryImage(CategoryImage categoryImage) =>
        Delete(categoryImage);
}
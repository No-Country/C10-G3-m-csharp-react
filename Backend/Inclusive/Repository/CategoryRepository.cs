﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class CategoryRepository : RepositoryBase<Category>,
    ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Category>> GetCategoriesAsync(CategoryParameters parameters,
        bool trackChanges)
    {
        var categories = await FindAll(trackChanges)
            .Include(c => c.Establishments)
            .SearchGeneric(parameters.SearchColumn,
                parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn,
                parameters.SortOrder)
            .ToListAsync();

        return PagedList<Category>.ToPagedList(categories,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id), trackChanges)
            .Include(c=> c.Establishments!)
            .ThenInclude(e => e.EstablishmentsAccessibilitys!)
            .ThenInclude(ea => ea.Accessibility) 
            .SingleOrDefaultAsync();

    public void CreateCategory(Category category) =>
        Create(category);

    public void DeleteCategory(Category category) =>
        Delete(category);
}
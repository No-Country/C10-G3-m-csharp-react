using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public CategoryService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetCategoriesAsync(
        CategoryParameters parameters,
        bool trackChanges)
    {
        var categoriesWithMetaData = await _repository.Categories.GetCategoriesAsync(parameters, trackChanges);
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categoriesWithMetaData);

        return (categoriesDto, categoriesWithMetaData.MetaData);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges)
    {
        var category = await GetCategoryAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        _repository.Categories.CreateCategory(categoryEntity);
        await _repository.SaveAsync();
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task DeleteCategoryAsync(Guid id, bool trackChanges)
    {
        var category = await GetCategoryAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Categories.DeleteCategory(category);
        await _repository.SaveAsync();
    }

    public async Task UpdateCategoryAsync(Guid id, CategoryForUpdateDto category, bool trackChanges)
    {
        var categoryEntity = await GetCategoryAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(category, categoryEntity);
        await _repository.SaveAsync();
    }

    private async Task<Category> GetCategoryAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var category = await _repository.Categories.GetCategoryByIdAsync(id, trackChanges);
        if (category is null) throw new CategoryNotFoundException(id);
        return category;
    }
}
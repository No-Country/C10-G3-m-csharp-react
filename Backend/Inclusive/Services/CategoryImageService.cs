using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services;

public class CategoryImageService : ICategoryImageService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public CategoryImageService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<CategoryImageDto> categoryImages, MetaData metaData)> GetCategoryImagesAsync(
        CategoryImageParameters parameters,
        bool trackChanges)
    {
        var categoryImagesWithMetaData =
            await _repository.CategoryImages.GetCategoryImagesAsync(parameters, trackChanges);
        var categoryImagesDto = _mapper.Map<IEnumerable<CategoryImageDto>>(categoryImagesWithMetaData);

        return (categoryImagesDto, categoryImagesWithMetaData.MetaData);
    }

    public async Task<(IEnumerable<CategoryImageDto> categoryImages, MetaData metaData)>
        GetCategoryImagesByCategoryAsync(Guid categoryId, CategoryImageParameters parameters, bool trackChanges)
    {
        await CheckIfCategoryExists(categoryId, trackChanges);

        var categoryImagesWithMetaData =
            await _repository.CategoryImages.GetCategoryImagesByCategoryAsync(categoryId, parameters, trackChanges);
        var categoryImagesDto = _mapper.Map<IEnumerable<CategoryImageDto>>(categoryImagesWithMetaData);

        return (categoryImagesDto, categoryImagesWithMetaData.MetaData);
    }

    public async Task<CategoryImageDto> GetCategoryImageByIdAsync(Guid id, bool trackChanges)
    {
        var categoryImage = await GetCategoryImageAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<CategoryImageDto>(categoryImage);
    }

    public async Task<CategoryImageDto> CreateCategoryImageAsync(Guid categoryId, CategoryImageForCreationDto category,
        bool trackChanges)
    {
        await CheckIfCategoryExists(categoryId, trackChanges);

        var categoryImageEntity = _mapper.Map<CategoryImage>(category);

        _repository.CategoryImages.CreateCategoryImage(categoryId, categoryImageEntity);
        await _repository.SaveAsync();

        return _mapper.Map<CategoryImageDto>(categoryImageEntity);
    }

    public async Task DeleteCategoryImageAsync(Guid id, bool trackChanges)
    {
        var categoryImage = await GetCategoryImageAndCheckIfItExists(id, trackChanges);
        _repository.CategoryImages.DeleteCategoryImage(categoryImage);
        await _repository.SaveAsync();
    }

    public async Task UpdateCategoryImageAsync(Guid categoryId, Guid id, CategoryImageForUpdateDto category,
        bool categoryTrackchanges, bool trackChanges)
    {
        await CheckIfCategoryExists(categoryId, categoryTrackchanges);

        var categoryEntity = await GetCategoryImageAndCheckIfItExists(id, trackChanges);
        _mapper.Map(category, categoryEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfCategoryExists(Guid categoryId,
        bool trackChanges)
    {
        var category = await _repository.Categories.GetCategoryByIdAsync(categoryId,
            trackChanges);
        if (category is null)
            throw new CategoryNotFoundException(categoryId);
    }

    private async Task<CategoryImage> GetCategoryImageAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var categoryImage = await _repository.CategoryImages.GetCategoryImageByIdAsync(id, trackChanges);
        if (categoryImage is null) throw new CategoryImageNotFoundException(id);
        return categoryImage;
    }
}
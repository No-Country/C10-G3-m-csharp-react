using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services;

public class ReviewService : IReviewService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ReviewService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    async Task<(IEnumerable<ReviewDto> reviewDtos, MetaData metaData)> IReviewService.GetReviewsAsync(ReviewParameters parameters, bool trackChanges)
    {
        var reviewsWithMetaData = await _repository.Reviews.GetReviewAsync(parameters, trackChanges);
        var reviewsDto = _mapper.Map<IEnumerable<ReviewDto>>(reviewsWithMetaData);

        return (reviewsDto, reviewsWithMetaData.MetaData);
    }

    async Task<ReviewDto> IReviewService.GetReviewByIdAsync(Guid id, bool trackChanges)
    {
        var review = await GetReviewAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<ReviewDto>(review);
    }

    public async Task<ReviewDto> CreateReviewAsync(Guid establishmentId, string userId, ReviewForCreationDto review, bool trackChanges)
    {
        var reviewEntity = _mapper.Map<Review>(review);
        reviewEntity.Created = DateTime.UtcNow;                    //Preguntar (Esta bien hacerlo aca? y esta bien el tipo?)
        _repository.Reviews.CreateReview(establishmentId, userId, reviewEntity);         //AGREGADO daba problemas en IReviewRepository
        await _repository.SaveAsync();
        return _mapper.Map<ReviewDto>(reviewEntity);
    }

    public async Task DeleteReviewAsync(Guid id, bool trackChanges)
    {
        var review = await GetReviewAndCheckIfItExists(id, trackChanges);
        _repository.Reviews.DeleteReview(review);
        await _repository.SaveAsync();
    }

    public async Task UpdateReviewAsync(Guid id, ReviewForUpdateDto review, bool trackChanges)
    {
        var reviewEntity = await GetReviewAndCheckIfItExists(id, trackChanges);
        _mapper.Map(review, reviewEntity);
        await _repository.SaveAsync();
    }

    private async Task<Review> GetReviewAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var review = await _repository.Reviews.GetReviewByIdAsync(id, trackChanges);
        if (review is null) throw new ReviewNotFoundException(id);
        return review;
    }
}

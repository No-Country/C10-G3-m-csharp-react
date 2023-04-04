using Shared.DataTransferObjects.ReviewDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IReviewService
{
    Task<(IEnumerable<ReviewDto> reviewDtos, MetaData metaData)> GetReviewsAsync(
        ReviewParameters parameters,
        bool trackChanges);

    Task<ReviewDto> GetReviewByIdAsync(Guid id,
        bool trackChanges);

    Task<ReviewDto> CreateReviewAsync(Guid establishmentId, string userId,
        ReviewForCreationDto review,
        bool trackChanges);

    Task DeleteReviewAsync(Guid establishmentId, string userId,
        Guid id,
        bool trackChanges);

    Task UpdateReviewAsync(Guid establishmentId, string userId,
        Guid id,
        ReviewForUpdateDto review,
        bool establishmentTrackChanges,
        bool trackChanges);
}
using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IReviewRepository
{
    Task<PagedList<Review>> GetReviewAsync(ReviewParameters parameters, bool trackChanges);
    Task<Review?> GetReviewByIdAsync(Guid id, bool trackChanges);
    void CreateReview(Guid establishmentId, string userId, Review review); //AGREGADO Viejo(Guid establishmentId, string userId, Review review)
    void DeleteReview(Review review);
}
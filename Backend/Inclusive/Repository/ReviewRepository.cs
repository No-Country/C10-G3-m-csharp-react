using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class ReviewRepository : RepositoryBase<Review>,
    IReviewRepository
{
    public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Review>> GetReviewAsync(ReviewParameters parameters,
        bool trackChanges)
    {
        var reviews = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn,
                parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn,
                parameters.SortOrder)
            .ToListAsync();

        return PagedList<Review>.ToPagedList(reviews,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Review?> GetReviewByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateReview(Guid establishmentId,
        string userId,
        Review review)
    {
        review.EstablishmentId = establishmentId;
        review.UserId = userId;
        Create(review);
    }

    public void DeleteReview(Review review)
    {
        Delete(review);
    }
}
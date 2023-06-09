﻿using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IReviewService
{
    Task<(IEnumerable<ReviewDto> reviewDtos, MetaData metaData)> GetReviewsAsync(ReviewParameters parameters, bool trackChanges);

    Task<ReviewDto> GetReviewByIdAsync(Guid id, bool trackChanges);

    Task<ReviewDto> CreateReviewAsync(Guid establishmentId, string userId, ReviewForCreationDto review, bool trackChanges);

    Task DeleteReviewAsync(Guid id, bool trackChanges);

    Task UpdateReviewAsync(Guid id,ReviewForUpdateDto review, bool trackChanges);
}
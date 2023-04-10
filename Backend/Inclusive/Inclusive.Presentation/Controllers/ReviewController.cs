using System.Text.Json;
using Entities.Models.Establishments;
using Entities.Models;
using Inclusive.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Inclusive.Presentation.Controllers;

[Route("api/review")]
[ApiController]
public class ReviewController: ControllerBase
{
    private readonly IServiceManager _service;

    public ReviewController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetReviews")]
    public async Task<IActionResult> GetReviews([FromQuery] ReviewParameters parameters)
    {
        var pagedResult = await _service.ReviewService.GetReviewsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.reviewDtos); //Los elementos estan en pagedResult.reviewDtos
    }

    [HttpGet("{id:guid}", Name = "GetReviewById")]
    public async Task<IActionResult> GetReviewById(Guid id)
    {
        var review = await _service.ReviewService.GetReviewByIdAsync(id, false);
        return Ok(review);
    }

    [HttpPost(Name = "CreateReview")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateReview(Guid establishmentId, string userId, [FromBody] ReviewForCreationDto review )
    {
        var createReview = await _service.ReviewService.CreateReviewAsync(establishmentId, userId, review, false);
        return CreatedAtRoute("GetReviewById", new { id = createReview.Id }, createReview);
    }

    [HttpPut("{id:guid}", Name = "UpdateReview")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateReview(Guid id, ReviewForUpdateDto review)
    {
        await _service.ReviewService.UpdateReviewAsync(id, review, true);
        return NoContent();
    }
}


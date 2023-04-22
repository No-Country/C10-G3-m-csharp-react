using Shared.DataTransferObjects.AccessibilityDtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.EstablishmentDtos;

public record EstablishmentDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Address { get; init; }

    public string? Latitude { get; init; }

    public string? Longitude { get; init; }

    public string? PhoneNumber { get; init; }

    public string? OpeningTime { get; set; }

    public string? ClosingTime { get; set; }

    public string? WebSite { get; init; }

    public string? Image { get; set; }

    public DateTime RequestedDate { get; init; }

    public RequestStatusEnum RequestStatus { get; init; }

    public DateTime ApprovedDate { get; init; }

    public Guid? ApprovalUserId { get; init; }

    public Guid CategoryId { get; init; }

    public IEnumerable<AccessibilityDto>? Accessibilitys { get; init; }

    public IEnumerable<ReviewDto>? Reviews { get; init; }

    public double AverageRating { get; set; }
}
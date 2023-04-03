using Shared.DataTransferObjects.ReviewDtos;

namespace Shared.DataTransferObjects.EstablishmentDtos;

public record EstablishmentDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Address { get; init; }

    public string? Latitude { get; init; }

    public string? Longitude { get; init; }

    public string? PhoneNumber { get; init; }

    public string? WebSite { get; init; }

    public string? Image { get; init; }

    public DateTime RequestedDate { get; init; }

    public RequestStatusEnum RequestStatus { get; init; }

    public DateTime ApprovedDate { get; init; }

    public Guid? ApprovalUserId { get; init; }

    public IEnumerable<ReviewDto>? Reviews { get; init; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects.EstablishmentDtos;

public abstract record EstablishmentForManipulationDto
{
    [Required(ErrorMessage = "Category is required")]
    public Guid CategoryId { get; init; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Address is required")]
    [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
    public string? Address { get; init; }

    public string? Latitude { get; init; }
    public string? Longitude { get; init; }

    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(15, ErrorMessage = "Phone Code cannot exceed 15 characters")]
    public string? PhoneNumber { get; init; }

    public string? WebSite { get; init; }
    public DateTime? RequestedDate { get; init; } = DateTime.Now;
    public RequestStatusEnum? RequestStatus { get; init; } = RequestStatusEnum.Pending;
    [JsonIgnore]
    public DateTime? ApprovedDate { get; init; }
    [JsonIgnore]
    public Guid? ApprovalUserId { get; init; }

    public List<Guid>? AccessibilityIds { get; set; }
}
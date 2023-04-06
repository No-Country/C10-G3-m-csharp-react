using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.ReviewDtos;

public abstract record ReviewForManipulationDto
{
    [Required(ErrorMessage = "Stablishment ID is required")]
    public Guid StablishmentId { get; set; }

    [Required(ErrorMessage = "User ID is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Rating value is required")]
    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(500, ErrorMessage = "Name can't exceed 500 characters")]
    public string? Comment { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.ReviewDtos;

public abstract record ReviewForManipulationDto
{
    [Required(ErrorMessage = "Rating value is required")]
    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(500, ErrorMessage = "Name can't exceed 500 characters")]
    public string? Comment { get; set; }
}
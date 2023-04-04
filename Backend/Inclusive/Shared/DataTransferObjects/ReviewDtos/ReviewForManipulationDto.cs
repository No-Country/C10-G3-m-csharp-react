using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DataTransferObjects.ReviewDtos;

public abstract record ReviewForManipulationDto
{
    [Required(ErrorMessage = "Rating is required")]
    [Range(0, 100, ErrorMessage = "Rating must be between 0 and 100")]
    public int? Rating { get; set; }

    [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
    public string? Comment { get; set; }
}
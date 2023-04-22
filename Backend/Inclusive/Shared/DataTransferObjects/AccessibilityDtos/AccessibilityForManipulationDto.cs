using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.AccessibilityDtos;

public abstract record AccessibilityForManipulationDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name must be less than 50 characters")]
    public string? Name { get; init; }

    //public int OrderNumber { get; init; }
}
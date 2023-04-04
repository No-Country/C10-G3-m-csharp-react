using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.CategoryDtos;

public abstract record CategoryForManipulationDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(60, ErrorMessage = "Name must be less than 60 characters")]
    public string? Name { get; init; }

    [MaxLength(255, ErrorMessage = "Description must be less than 255 characters")]
    public string? Description { get; init; }
}
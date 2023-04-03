using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.CategoryDtos;

public record CategoryForCreationDto : CategoryForManipulationDto
{
    public IFormFile? Image { get; init; }
}
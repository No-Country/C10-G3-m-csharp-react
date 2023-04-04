using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.CategoryDtos;

public record CategoryForUpdateDto : CategoryForManipulationDto
{
    public IFormFile? Image { get; init; }
}
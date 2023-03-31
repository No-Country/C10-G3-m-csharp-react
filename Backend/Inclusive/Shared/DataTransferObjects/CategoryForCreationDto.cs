using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects;

public record CategoryForCreationDto : CategoryForManipulationDto
{
    public IFormFile? Image { get; set; }
}
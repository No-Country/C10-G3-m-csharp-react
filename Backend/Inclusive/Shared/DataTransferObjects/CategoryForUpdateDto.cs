using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects;

public record CategoryForUpdateDto : CategoryForManipulationDto
{
    public IFormFile? Image { get; set; }
}
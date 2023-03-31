using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects;

public record CategoryImageForCreationDto : CategoryImageForManipulationDto
{
    public IEnumerable<IFormFile>? CategoryImages { get; set; }
}
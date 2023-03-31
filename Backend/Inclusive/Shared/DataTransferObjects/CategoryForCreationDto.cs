using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects;

public record CategoryForCreationDto : CategoryForManipulationDto
{
    public IEnumerable<IFormFile>? CategoryImages { get; set; }
}
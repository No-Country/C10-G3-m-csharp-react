using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.EstablishmentDtos;

public record EstablishmentForCreationDto : EstablishmentForManipulationDto
{
    public IFormFile? Image { get; init; }
}
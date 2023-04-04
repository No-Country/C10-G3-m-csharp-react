using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.EstablishmentDtos;

public record EstablishmentForUpdateDto : EstablishmentForManipulationDto
{
    public IFormFile? Image { get; init; }
}
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.OwnerDtos;

namespace Shared.DataTransferObjects.EstablishmentDtos;

public record EstablishmentForCreationDto : EstablishmentForManipulationDto
{
    public IFormFile? Image { get; init; }

    public OwnerForCreationDto? Owner { get; init; }
}
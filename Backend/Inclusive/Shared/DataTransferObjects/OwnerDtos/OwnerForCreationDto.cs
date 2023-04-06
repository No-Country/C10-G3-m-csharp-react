using Shared.DataTransferObjects.EstablishmentDtos;

namespace Shared.DataTransferObjects.OwnerDtos;

public record OwnerForCreationDto : OwnerForManipulationDto
{
    public EstablishmentForCreationDto? Establishment { get; init; }
}
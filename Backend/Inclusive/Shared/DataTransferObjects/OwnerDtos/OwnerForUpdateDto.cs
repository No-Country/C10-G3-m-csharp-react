using Shared.DataTransferObjects.EstablishmentDtos;

namespace Shared.DataTransferObjects.OwnerDtos;

public record OwnerForUpdateDto : OwnerForManipulationDto
{
    public EstablishmentForUpdateDto? Establishment { get; init; }
}
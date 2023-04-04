using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IEstablishmentService
{
    Task<(IEnumerable<EstablishmentDto> establishmentDtos, MetaData metaData)> GetEstablishmentsAsync(
        EstablishmentParameters parameters,
        bool trackChanges);

    Task<EstablishmentDto> GetEstablishmentByIdAsync(Guid id,
        bool trackChanges);

    Task<EstablishmentDto> CreateEstablishmentAsync(Guid ownerId,
        EstablishmentForCreationDto establishment,
        bool trackChanges);

    Task DeleteEstablishmentAsync(Guid ownerId,
        Guid id,
        bool trackChanges);

    Task UpdateEstablishmentAsync(Guid ownerId,
        Guid id,
        EstablishmentForUpdateDto establishment,
        bool ownerTrackChanges,
        bool trackChanges);
}
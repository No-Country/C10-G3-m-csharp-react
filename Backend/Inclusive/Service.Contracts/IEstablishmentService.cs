using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IEstablishmentService
{
    Task<(IEnumerable<EstablishmentDto> establishmentDtos, MetaData metaData)> GetEstablishmentsAsync(
        EstablishmentParameters parameters,
        bool trackChanges);

    Task<EstablishmentDto> GetEstablishmentByIdAsync(Guid id, bool trackChanges);

    Task<EstablishmentDto> CreateEstablishmentAsync(EstablishmentForCreationDto establishment,
        bool trackChanges);

    Task DeleteEstablishmentAsync(Guid id, bool trackChanges);

    Task UpdateEstablishmentAsync(Guid id, EstablishmentForUpdateDto establishment, bool trackChanges);
}
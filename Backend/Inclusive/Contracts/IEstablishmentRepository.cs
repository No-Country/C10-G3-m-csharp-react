using Entities.Models.Establishments;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.RequestFeatures;

namespace Contracts;

public interface IEstablishmentRepository
{
    Task<PagedList<Establishment>> GetEstablishmentAsync(EstablishmentParameters parameters, bool trackChanges);

    Task<Establishment?> GetEstablishmentByIdAsync(Guid id, bool trackChanges);

    Task GetEstablishmentAverageRatingAsync(IEnumerable<EstablishmentDto> establishmentDtos);

    void CreateEstablishment(Establishment establishment);
    void DeleteEstablishment(Establishment establishment);
}
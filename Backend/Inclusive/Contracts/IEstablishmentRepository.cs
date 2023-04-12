using Entities.Models.Establishments;
using Shared.RequestFeatures;

namespace Contracts;

public interface IEstablishmentRepository
{
    Task<PagedList<Establishment>> GetEstablishmentAsync(EstablishmentParameters parameters, bool trackChanges);
    Task<Establishment?> GetEstablishmentByIdAsync(Guid id, bool trackChanges);
    void CreateEstablishment(Establishment establishment);
    void DeleteEstablishment(Establishment establishment);
}
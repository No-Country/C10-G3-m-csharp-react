using Entities.Models.Owners;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOwnerRepository
{
    Task<PagedList<Owner>> GetOwnersAsync(OwnerParameters parameters, bool trackChanges);
    void CreateOwner(Owner owner);
    Task<Owner?> GetOwnerByIdAsync(Guid id, bool trackChanges);
    void DeleteOwner(Owner owner);
}
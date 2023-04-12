using Contracts;
using Entities.Models.Owners;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Owner>> GetOwnersAsync(OwnerParameters parameters,
        bool trackChanges)
    {
        var owners = await FindAll(trackChanges)
            .Include(o=>o.Establishments)
            .SearchGeneric(parameters.SearchColumn,
                parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn,
                parameters.SortOrder)
            .ToListAsync();
        return PagedList<Owner>.ToPagedList(owners,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Owner?> GetOwnerByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(o => o.Id.Equals(id),
                trackChanges)
            .Include(o => o.Establishments)
            .SingleOrDefaultAsync();

    public void CreateOwner(Owner owner) =>
        Create(owner);

    public void DeleteOwner(Owner owner) =>
        Delete(owner);
}
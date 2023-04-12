using Contracts;
using Entities.Models.Establishments;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class EstablishmentRepository : RepositoryBase<Establishment>,
    IEstablishmentRepository
{
    public EstablishmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Establishment>> GetEstablishmentAsync(EstablishmentParameters parameters,
        bool trackChanges)
    {
        var establishments = await FindAll(trackChanges)
            .Include(e => e.EstablishmentsAccessibilitys!)
            .ThenInclude(ea => ea.Accessibility)
            .Include(e => e.Reviews)
            .SearchGeneric(parameters.SearchColumn,
                parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn,
                parameters.SortOrder)
            .ToListAsync();

        return PagedList<Establishment>.ToPagedList(establishments,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Establishment?> GetEstablishmentByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(e => e.Id.Equals(id), trackChanges)
            .Include(e => e.EstablishmentsAccessibilitys!)
            .ThenInclude(ea => ea.Accessibility)
            .Include(e => e.Reviews)
            .SingleOrDefaultAsync();

    public void CreateEstablishment(Establishment establishment)
    {
        Create(establishment);
    }

    public void DeleteEstablishment(Establishment establishment)
    {
        Delete(establishment);
    }
}
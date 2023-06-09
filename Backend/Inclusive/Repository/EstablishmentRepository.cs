﻿using Contracts;
using Entities.Models.Establishments;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.RequestFeatures;

namespace Repository;

public class EstablishmentRepository : RepositoryBase<Establishment>,
    IEstablishmentRepository
{
    private readonly RepositoryContext _repositoryContext;
    public EstablishmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public async Task<PagedList<Establishment>> GetEstablishmentAsync(EstablishmentParameters parameters,
        bool trackChanges)
    {
        var establishments = await FindAll(trackChanges)
            .Include(e => e.EstablishmentsAccessibilitys!)
            .ThenInclude(ea => ea.Accessibility)
            .Include(e => e.Reviews)
            .FilterGeneric(parameters.FilterColumn, parameters.FilterValue)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
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

    public async Task GetEstablishmentAverageRatingAsync(IEnumerable<EstablishmentDto> establishmentDtos)
    {
        if (establishmentDtos.Count() > 0)
        {
            var establishmentIds = establishmentDtos.Select(e => e.Id).Distinct();

            var averageRating = await _repositoryContext.Reviews!
                .Where(r => establishmentIds.Select(id => id.ToString()).Contains(r.EstablishmentId.ToString()))
                .GroupBy(r => r.EstablishmentId)
                .Select(g => new { EstablishmentId = g.Key, AverageRating = g.Average(r => r.Rating) })
                .ToListAsync();

            foreach (var establishment in establishmentDtos)
            {
                establishment.AverageRating = averageRating.FirstOrDefault(pr => 
                    pr.EstablishmentId == establishment.Id)?.AverageRating ?? 0.0;
            }
        }
    }
}
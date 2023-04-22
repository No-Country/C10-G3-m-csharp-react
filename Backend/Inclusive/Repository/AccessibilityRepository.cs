using Contracts;
using Entities.Models;
using Entities.Models.Establishments;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;


namespace Repository
{
    public class AccessibilityRepository : RepositoryBase<Accessibility>, IAccessibilityRepository
    {
        public AccessibilityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAccessibility(Accessibility accessibility) =>
            Create(accessibility);

        public void DeleteAccessibility(Accessibility accessibility) =>
            Delete(accessibility);

        public async Task<List<Accessibility>> GetAccessibilitysAsync(AccessibilityParameters parameters,
            bool trackChanges)
        {
            var accessibilitys = await FindAll(trackChanges)
                .SearchGeneric(parameters.SearchColumn,
                    parameters.SearchTerm)
                .SortGeneric(parameters.SortColumn,
                    parameters.SortOrder)
                .ToListAsync();

            return accessibilitys;
        }

        public async Task<Accessibility?> GetAccessibilityByIdAsync(Guid id, bool trackChanges)=>
            await FindByCondition(d => d.Id.Equals(id),
                    trackChanges)
                .SingleOrDefaultAsync();

        //private async Task<Accessibility?> GetAccessibility(Guid id, bool trackChanges, string Ids) =>
        //    await FindByCondition(a => Ids.Contains(a.Id)).Select(x => x.Id,
        //            trackChanges)
        //        .ToListAsync();

        /*
         *  var accessibilityIds = await _repository.Accessibilitys
            .Where(a => establishment.AccessibilityIds.Contains(a.Id)).Select(x => x.Id).ToListAsync();
         */
    }
}

using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IAccessibilityRepository
    {
        Task<List<Accessibility>> GetAccessibilitysAsync(AccessibilityParameters parameters, bool trackChanges);
        void CreateAccessibility(Accessibility accessibility);
        Task<Accessibility?> GetAccessibilityByIdAsync(Guid id, bool trackChanges);
        void DeleteAccessibility(Accessibility accessibility);
    }
}

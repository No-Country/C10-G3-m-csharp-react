
using Shared.DataTransferObjects.AccessibilityDtos;
using Shared.DataTransferObjects.CategoryDtos;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IAccessibilityService
    {
        Task<IEnumerable<AccessibilityDto>> GetAccessibilitysAsync(AccessibilityParameters parameters,
            bool trackChanges);

        Task<AccessibilityDto> GetAccessibilityByIdAsync(Guid id, bool trackChanges);
        Task<AccessibilityDto> CreateAccessibilityAsync(AccessibilityForCreationDto accessibility);
        Task DeleteAccessibilityAsync(Guid id, bool trackChanges);
        Task UpdateAccessibilityAsync(Guid id, AccessibilityForUpdateDto accessibility, bool trackChanges);
    }
}
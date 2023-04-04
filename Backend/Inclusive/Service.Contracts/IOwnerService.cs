using Shared.DataTransferObjects.OwnerDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IOwnerService
{
    Task<(IEnumerable<OwnerDto> ownerDtos, MetaData metaData)> GetOwnersAsync(OwnerParameters parameters,
        bool trackChanges);
    Task<OwnerDto> GetOwnerByIdAsync(Guid id, bool trackChanges);
    Task<OwnerDto> CreateOwnerAsync(OwnerForCreationDto owner);
    Task DeleteOwnerAsync(Guid id, bool trackChanges);
    Task UpdateOwnerAsync(Guid id, OwnerForUpdateDto owner, bool trackChanges);
}
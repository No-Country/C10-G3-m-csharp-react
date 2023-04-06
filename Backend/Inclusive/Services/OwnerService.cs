using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Owners;
using Service.Contracts;
using Shared.DataTransferObjects.OwnerDtos;
using Shared.RequestFeatures;

namespace Services;

public class OwnerService : IOwnerService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public OwnerService(IRepositoryManager repository,
        IMapper mapper,
        ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<OwnerDto> ownerDtos, MetaData metaData)> GetOwnersAsync(OwnerParameters parameters,
        bool trackChanges)
    {
        var ownersWithMetadata = await _repository.Owners.GetOwnersAsync(parameters,
            trackChanges);
        var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(ownersWithMetadata);

        return (ownersDto, ownersWithMetadata.MetaData);
    }

    public async Task<OwnerDto> GetOwnerByIdAsync(Guid id,
        bool trackChanges)
    {
        var owner = await _repository.Owners.GetOwnerByIdAsync(id,
            trackChanges);
        return _mapper.Map<OwnerDto>(owner);
    }

    public async Task<OwnerDto> CreateOwnerAsync(Guid categoryId, OwnerForCreationDto owner)
    {
        var ownerEntity = _mapper.Map<Owner>(owner);
        ownerEntity.Establishment!.CategoryId = categoryId;
        _repository.Owners.CreateOwner(ownerEntity);
        await _repository.SaveAsync();
        return _mapper.Map<OwnerDto>(ownerEntity);
    }

    public async Task DeleteOwnerAsync(Guid id,
        bool trackChanges)
    {
        var ownerEntity = await GetOwnerAndCheckIfItExists(id,
            trackChanges);
        _repository.Owners.DeleteOwner(ownerEntity);
        await _repository.SaveAsync();
    }

    public async Task UpdateOwnerAsync(Guid id,
        OwnerForUpdateDto owner,
        bool trackChanges)
    {
        var ownerEntity = await GetOwnerAndCheckIfItExists(id, trackChanges);
        _mapper.Map(owner, ownerEntity);
        await _repository.SaveAsync();
    }

    private async Task<Owner> GetOwnerAndCheckIfItExists(Guid id,
        bool trackChanges)
    {
        var owner = await _repository.Owners.GetOwnerByIdAsync(id,
             trackChanges);
        return owner ?? throw new OwnerNotFoundException(id);
    }
}
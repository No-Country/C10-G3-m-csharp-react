using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Establishments;
using Service.Contracts;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.RequestFeatures;

namespace Services;

public class EstablishmentService : IEstablishmentService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public EstablishmentService(IRepositoryManager repository,
        IMapper mapper,
        ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<EstablishmentDto> establishmentDtos, MetaData metaData)> GetEstablishmentsAsync(
        EstablishmentParameters parameters,
        bool trackChanges)
    {
        var establishmentsWithDto = await _repository.Establishments.GetEstablishmentAsync(parameters, trackChanges);
        var establishmentDtos = _mapper.Map<IEnumerable<EstablishmentDto>>(establishmentsWithDto);

        return (establishmentDtos, establishmentsWithDto.MetaData);
    }

    public async Task<EstablishmentDto> GetEstablishmentByIdAsync(Guid id,
        bool trackChanges)
    {
       var establishment = await _repository.Establishments.GetEstablishmentByIdAsync(id, trackChanges);
       return _mapper.Map<EstablishmentDto>(establishment);
    }

    public async Task<EstablishmentDto> CreateEstablishmentAsync(Guid ownerId,
        EstablishmentForCreationDto establishment,
        bool trackChanges)
    {
        await CheckIfOwnerExists(ownerId, trackChanges);
        var establishmentEntity = _mapper.Map<Establishment>(establishment);
        _repository.Establishments.CreateEstablishment(ownerId, establishmentEntity);
        await _repository.SaveAsync();
        return _mapper.Map<EstablishmentDto>(establishmentEntity);
    }

    public Task DeleteEstablishmentAsync(Guid ownerId,
        Guid id,
        bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEstablishmentAsync(Guid ownerId,
        Guid id,
        EstablishmentForUpdateDto establishment,
        bool ownerTrackChanges,
        bool trackChanges)
    {
        throw new NotImplementedException();
    }
    private async Task CheckIfOwnerExists(Guid ownerId,
        bool trackChanges)
    {
        var owner = await _repository.Owners.GetOwnerByIdAsync(ownerId,
            trackChanges);
        if (owner is null)
            throw new OwnerNotFoundException(ownerId);
    }

    private async Task<Establishment> GetEstablishmentForOwnerAndCheckIfItExists(Guid id,
        bool trackChanges)
    {
        var establishmentDb = await _repository.Establishments.GetEstablishmentByIdAsync(id,
            trackChanges);
        if (establishmentDb is null)
            throw new EstablishmentNotFoundException(id);
        return establishmentDb;
    }
}
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

        await _repository.Establishments.GetEstablishmentAverageRatingAsync(establishmentDtos);

        return (establishmentDtos, establishmentsWithDto.MetaData);
    }

    public async Task<EstablishmentDto> GetEstablishmentByIdAsync(Guid id, bool trackChanges)
    {
        var establishment = await _repository.Establishments.GetEstablishmentByIdAsync(id, trackChanges);

        ICollection<EstablishmentDto> establishmentDtos = new List<EstablishmentDto>();
        establishmentDtos.Add(_mapper.Map<EstablishmentDto>(establishment));
        await _repository.Establishments.GetEstablishmentAverageRatingAsync(establishmentDtos);

        return establishmentDtos.FirstOrDefault()!;
    }

    public async Task<EstablishmentDto> CreateEstablishmentAsync(
        EstablishmentForCreationDto establishment,
        bool trackChanges)
    {
    
        if (establishment.AccessibilityIds == null)
        {
            throw new AccessibilityBadRequestException(string.Empty);
        }

        /*  
         *  *** VER ESTAS VALIDACIONES
        var accessibilityIds = await _repository.Accessibilitys
            .Where(a => establishment.AccessibilityIds.Contains(a.Id)).Select(x => x.Id).ToListAsync();

        if (establishment.AccessibilityIds.Count != accessibilityIds.Count)
        {
            //return BadRequest("No existe una de las accesibilidades enviados");
        }
        */

        var establishmentEntity = _mapper.Map<Establishment>(establishment);

        AssignOrderNumberAccessibilitys(establishmentEntity);

        _repository.Establishments.CreateEstablishment(establishmentEntity);
        await _repository.SaveAsync();

        return await GetEstablishmentByIdAsync(establishmentEntity.Id, false);
    }

    public async Task DeleteEstablishmentAsync(
        Guid id,
        bool trackChanges)
    {
        var establishment = await GetEstablishmentAndCheckIfItExists(id, trackChanges);
        _repository.Establishments.DeleteEstablishment(establishment);
        await _repository.SaveAsync();
    }

    public async Task UpdateEstablishmentAsync(
        Guid id,
        EstablishmentForUpdateDto establishment,
        bool trackChanges)
    {
        if (establishment.AccessibilityIds == null)
        {
            throw new AccessibilityBadRequestException(string.Empty);
        }

        var establishmentEntity = await GetEstablishmentAndCheckIfItExists(id, trackChanges);

        establishmentEntity = _mapper.Map(establishment, establishmentEntity);

        AssignOrderNumberAccessibilitys(establishmentEntity);

        await _repository.SaveAsync();
    }
                                      
    private async Task<Establishment> GetEstablishmentAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var establishmentDb = await _repository.Establishments.GetEstablishmentByIdAsync(id,
            trackChanges);
        if (establishmentDb is null)
            throw new EstablishmentNotFoundException(id);
        return establishmentDb;
    }

    private void AssignOrderNumberAccessibilitys(Establishment establishment)
    {
        if (establishment.EstablishmentsAccessibilitys != null)
        {
            for (int i = 0; i < establishment.EstablishmentsAccessibilitys.Count; i++)
            {
                establishment.EstablishmentsAccessibilitys.ElementAt(i).OrderNumber = i + 1;
            }
        }
    }
}
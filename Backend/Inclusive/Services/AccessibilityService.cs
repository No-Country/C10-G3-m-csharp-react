using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.AccessibilityDtos;
using Shared.RequestFeatures;


namespace Services
{
    public class AccessibilityService : IAccessibilityService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public AccessibilityService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AccessibilityDto> CreateAccessibilityAsync(AccessibilityForCreationDto accessibility)
        {
            var accessibilityEntity = _mapper.Map<Accessibility>(accessibility);

            var accessibilitys = await _repository.Accessibilitys.GetAccessibilitysAsync(new AccessibilityParameters(), false);
            if (accessibilitys.Count == 0)
            {
                accessibilityEntity.OrderNumber = 1;
            }
            else
            {
                int maxOrderNumber = accessibilitys.Max(x => x.OrderNumber);
                accessibilityEntity.OrderNumber = maxOrderNumber + 1;
            }

            _repository.Accessibilitys.CreateAccessibility(accessibilityEntity);
            await _repository.SaveAsync();
            return _mapper.Map<AccessibilityDto>(accessibilityEntity);
        }

        public async Task DeleteAccessibilityAsync(Guid id, bool trackChanges)
        {
            var accessibility = await GetAccessibilityAndCheckIfItExists(id: id, trackChanges: trackChanges);
            _repository.Accessibilitys.DeleteAccessibility(accessibility);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<AccessibilityDto>> GetAccessibilitysAsync(AccessibilityParameters parameters, bool trackChanges)
        {
            var accessibilitys = await _repository.Accessibilitys.GetAccessibilitysAsync(parameters, trackChanges);
            var accessibilitysDto = _mapper.Map<IEnumerable<AccessibilityDto>>(accessibilitys);

            return accessibilitysDto;
        }

        public async Task<AccessibilityDto> GetAccessibilityByIdAsync(Guid id, bool trackChanges)
        {
            var accessibility = await GetAccessibilityAndCheckIfItExists(id: id, trackChanges: trackChanges);
            return _mapper.Map<AccessibilityDto>(accessibility);
        }

        public async Task UpdateAccessibilityAsync(Guid id, AccessibilityForUpdateDto accessibility, bool trackChanges)
        {
            var accessibilityEntity = await GetAccessibilityAndCheckIfItExists(id: id, trackChanges: trackChanges);
            _mapper.Map(accessibility, accessibilityEntity);
            await _repository.SaveAsync();
        }

        private async Task<Accessibility> GetAccessibilityAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var accessibility = await _repository.Accessibilitys.GetAccessibilityByIdAsync(id, trackChanges);
            if (accessibility is null)
                throw new AccessibilityNotFoundException(id);
            return accessibility;
        }
    }
}

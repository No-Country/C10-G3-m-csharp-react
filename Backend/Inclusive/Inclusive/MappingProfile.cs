using AutoMapper;
using Entities.Models;
using Entities.Models.Establishments;
using Entities.Models.Owners;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AccessibilityDtos;
using Shared.DataTransferObjects.CategoryDtos;
using Shared.DataTransferObjects.EstablishmentDtos;
using Shared.DataTransferObjects.OwnerDtos;
using Shared.DataTransferObjects.UserDtos;

namespace Inclusive;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForCreationDto, Category>()
            .ForMember(c => c.Image,
                opt => opt.Ignore());
        CreateMap<CategoryForUpdateDto, Category>()
            .ForMember(c => c.Image,
                opt => opt.Ignore());

        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForUpdateDto, User>();
        CreateMap<User, UserDto>();

        CreateMap<Owner, OwnerDto>();
        CreateMap<OwnerForCreationDto, Owner>();
        CreateMap<OwnerForUpdateDto, Owner>();

        CreateMap<Establishment, EstablishmentDto>()
            .ForMember(e => e.Accessibilitys, opt => opt.MapFrom(MapEstablishmentsAccessibilitys));
        CreateMap<EstablishmentForCreationDto, Establishment>()
            .ForMember(e => e.Image, opt => opt.Ignore())
            .ForMember(e => e.EstablishmentsAccessibilitys, opt => opt.MapFrom(MapEstablishmentsAccessibilitys));
        CreateMap<EstablishmentForUpdateDto, Establishment>()
            .ForMember(e => e.Image, opt => opt.Ignore())
            .ForMember(e => e.EstablishmentsAccessibilitys, opt => opt.MapFrom(MapEstablishmentsAccessibilitys));

        CreateMap<Accessibility, AccessibilityDto>();
        CreateMap<AccessibilityForCreationDto, Accessibility>();
        CreateMap<AccessibilityForUpdateDto, Accessibility>();

        CreateMap<ReviewForCreationDto, Review>();
        CreateMap<Review, ReviewDto>();
        CreateMap<ReviewForUpdateDto, Review>();
    }

    private List<EstablishmentAccessibility> MapEstablishmentsAccessibilitys(
        EstablishmentForCreationDto establishmentForCreationDto, Establishment establishment)
    {
        var result = new List<EstablishmentAccessibility>();

        if (establishmentForCreationDto.AccessibilityIds == null) { return result; }

        foreach (var accessibilityId in establishmentForCreationDto.AccessibilityIds)
        {
            result.Add(new EstablishmentAccessibility() { AccessibilityId = accessibilityId });
        }

        return result;
    }

    private List<EstablishmentAccessibility> MapEstablishmentsAccessibilitys(
    EstablishmentForUpdateDto establishmentForCreationDto, Establishment establishment)
    {
        var result = new List<EstablishmentAccessibility>();

        if (establishmentForCreationDto.AccessibilityIds == null) { return result; }

        foreach (var accessibilityId in establishmentForCreationDto.AccessibilityIds)
        {
            result.Add(new EstablishmentAccessibility() { AccessibilityId = accessibilityId });
        }

        return result;
    }


    private List<AccessibilityDto> MapEstablishmentsAccessibilitys(Establishment establishment, EstablishmentDto establishmentDto)
    {
        var result = new List<AccessibilityDto>();
        if(establishment.EstablishmentsAccessibilitys  == null ) { return result; }

        foreach (var establishmentAccessibility in establishment.EstablishmentsAccessibilitys)
        {
            result.Add(new AccessibilityDto()
            {
                Id = establishmentAccessibility.AccessibilityId,
                Name= establishmentAccessibility.Accessibility!.Name,
                OrderNumber= establishmentAccessibility.OrderNumber
            });
        }

        return result;
    }
}
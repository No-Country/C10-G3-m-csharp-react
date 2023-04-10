using AutoMapper;
using Entities.Models;
using Entities.Models.Establishments;
using Entities.Models.Owners;
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

        CreateMap<Establishment, EstablishmentDto>();
        CreateMap<EstablishmentForCreationDto, Establishment>()
            .ForMember(e=> e.Image,
                opt=> opt.Ignore());
        CreateMap<EstablishmentForUpdateDto, Establishment>()
            .ForMember(e=> e.Image,
                opt=> opt.Ignore());

        CreateMap<Accessibility, AccessibilityDto>();
        CreateMap<AccessibilityForCreationDto, Accessibility>();
        CreateMap<AccessibilityForUpdateDto, Accessibility>();

        CreateMap<ReviewForCreationDto, Review>();
        CreateMap<Review, ReviewDto>();
        CreateMap<ReviewForUpdateDto, Review>();
    }
}
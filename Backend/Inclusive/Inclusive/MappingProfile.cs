using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

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
    }
}
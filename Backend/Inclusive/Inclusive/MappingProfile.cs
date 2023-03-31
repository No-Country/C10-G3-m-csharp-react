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
            .ForMember(c => c.CategoryImages,
                opt => opt.Ignore());
        CreateMap<CategoryImage, CategoryImageDto>();

        CreateMap<UserForRegistrationDto, User>();
    }
}
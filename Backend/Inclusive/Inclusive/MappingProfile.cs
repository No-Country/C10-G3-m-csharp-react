using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.CategoryDtos;
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

        CreateMap<ReviewForCreationDto, Review>();
        CreateMap<Review, ReviewDto>();
        CreateMap<ReviewForUpdateDto, Review>();
    }
}
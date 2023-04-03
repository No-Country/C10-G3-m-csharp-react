using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.User;

namespace Inclusive;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForCreationDto, Category>();

        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForUpdateDto, User>();
        CreateMap<User, UserDto>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Shared.DataTransferObjects.UserDtos;

public record UserForRegistrationDto: UserForManipulationDto
{
    [Required(ErrorMessage = "Password es requerido")]
    public string? Password { get; init; }

    //public string? PhoneNumber { get; init; }
    //public ICollection<string>? Roles { get; init; }
}
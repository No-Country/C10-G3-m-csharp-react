using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Shared.DataTransferObjects;

public record UserForRegistrationDto
{
    //[Required(ErrorMessage = "First Name is a Required field.")]
    //[DataType(DataType.Text)]
    //[Display(Order = 1, Name = "FirstName")]
    //[RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "First name is required and must be properly formatted.")]

    [Required(ErrorMessage = "El nombre es requerido")]
    public string? FirstName { get; init; }


    //[Required(ErrorMessage = "Last Name is a Required field.")]
    //[DataType(DataType.Text)]
    //[Display(Order = 2, Name = "LastName")]
    //[RegularExpression("^((?!^Last Name$)[a-zA-Z '])+$", ErrorMessage = "Last name is required and must be properly formatted.")]

    [Required(ErrorMessage = "El apellido es requerido")]
    public string? LastName { get; init; }


    //[Required(ErrorMessage = "Email is a Required field.")]
    //[DataType(DataType.EmailAddress)]

    //  alkemy           "^[_a-z0-9A-Z]+(\\.[_a-z0-9A-Z]+)*@[a-zA-Z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-zA-Z]{2,15})$"
    //[RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
    //    ErrorMessage = "Email is required and must be properly formatted.")]

    //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
    //                        ErrorMessage = "Please enter a valid email address")]


    [Required(ErrorMessage = "El Email es requerido")]
    public string? Email { get; init; }



    //[Display(Name = "Username")]
    //[Required(ErrorMessage = "Username is required.")]
    //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

    //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]

    [Required(ErrorMessage = "Username es requerido")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password es requerido")]
    public string? Password { get; init; }

    //public string? PhoneNumber { get; init; }
    //public ICollection<string>? Roles { get; init; }
}
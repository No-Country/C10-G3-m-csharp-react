using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.UserDtos;

public abstract record UserForManipulationDto
{
    [Required(ErrorMessage = "First Name is a Required field.")]
    [DataType(DataType.Text)]
    [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "First name is required and must be properly formatted.")]
    public string? FirstName { get; init; }


    [Required(ErrorMessage = "Last Name is a Required field.")]
    [DataType(DataType.Text)]
    [RegularExpression("^((?!^Last Name$)[a-zA-Z '])+$", ErrorMessage = "Last name is required and must be properly formatted.")]
    public string? LastName { get; init; }


    //[Required(ErrorMessage = "El Email es requerido")]
    [Required(ErrorMessage = "Email is a Required field.")]
    [DataType(DataType.EmailAddress)]

    //  aemy           "^[_a-z0-9A-Z]+(\\.[_a-z0-9A-Z]+)*@[a-zA-Z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-zA-Z]{2,15})$"
    //[RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
    //    ErrorMessage = "Email is required and must be properly formatted.")]

    [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email address")]

    public string? Email { get; init; }


    [Required(ErrorMessage = "Username es requerido")]
    //[Required(ErrorMessage = "Username is required.")]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
    //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
    public string? UserName { get; init; }
}
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class User : IdentityUser
{
    [Required(ErrorMessage = "First Name is required")]
    [MaxLength(60, ErrorMessage = "First Name must be less than 60 characters")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [MaxLength(60, ErrorMessage = "Last Name must be less than 60 characters")]
    public string? LastName { get; set; }
}
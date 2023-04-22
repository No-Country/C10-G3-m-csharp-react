using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.OwnerDtos;

public abstract record OwnerForManipulationDto
{

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string? Name { get; init; }


    [Required(ErrorMessage = "Surnames is required")]
    [MaxLength(50, ErrorMessage = "Surnames cannot exceed 50 characters")]
    public string? SurNames { get; init; }


    [Required(ErrorMessage = "DNI is required")]
    [MaxLength(11, ErrorMessage = "DNI cannot exceed 11 characters")]
    public string? Dni { get; init; }


    [Required(ErrorMessage = "Gender is required")]
    public GenderEnum? Gender { get; init; } = GenderEnum.Other;


    [Required(ErrorMessage = "Nationality is required")]
    public NationalityEnum Nationality { get; init; } = NationalityEnum.Other;


    [MaxLength(ErrorMessage = "Tramit Number cannot exceed 50 characters")]
    public string? TramitNumber { get; init; }

    public DateTime BirthDate { get; init; }


    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(10, ErrorMessage = "Phone Code cannot exceed 10 characters")]
    public string? PhoneCode { get; init; }


    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(15, ErrorMessage = "Phone Number cannot exceed 15 characters")]
    public string? PhoneNumber { get; init; }


    [Required(ErrorMessage = "Marital Status is required")]
    public MaritalStatusEnum MaritalStatus { get; init; } = MaritalStatusEnum.Other;


    [Required(ErrorMessage = "PEP is required")]
    public bool Pep { get; init; }
}
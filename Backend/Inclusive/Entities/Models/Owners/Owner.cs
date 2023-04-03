using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Establishments;

namespace Entities.Models.Owners;

public class Owner
{
    [Column("OwnerId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Surnames is required")]
    [MaxLength(50, ErrorMessage = "Surnames cannot exceed 50 characters")]
    public string? SurNames { get; set; }

    [Required(ErrorMessage = "DNI is required")]
    [MaxLength(11, ErrorMessage = "DNI cannot exceed 11 characters")]
    public string? Dni { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public GenderEnum? Gender { get; set; }

    [Required(ErrorMessage = "Nationality is required")]
    public NationalityEnum? Nationality { get; set; }

    [MaxLength(ErrorMessage = "Tramit Number cannot exceed 50 characters")]
    public string? TramitNumber { get; set; }

    [Column(TypeName = "date")] public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(10, ErrorMessage = "Phone Code cannot exceed 10 characters")]
    public string? PhoneCode { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(15, ErrorMessage = "Phone Number cannot exceed 15 characters")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Marital Status is required")]
    public MaritalStatusEnum? MaritalStatus { get; set; }

    [Required(ErrorMessage = "PEP is required")]
    public char? Pep { get; set; }

    public Establishment? Establishment { get; set; }
}
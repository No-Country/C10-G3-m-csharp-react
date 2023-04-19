using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Owners;

namespace Entities.Models.Establishments;

public class Establishment
{
    [Column("EstablishmentId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
    public string? Address { get; set; }

    [MaxLength(20, ErrorMessage = "Latitude cannot exceed 20 characters")]
    public string? Latitude { get; set; }

    [MaxLength(20, ErrorMessage = "Longitude cannot exceed 20 characters")]
    public string? Longitude { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(15, ErrorMessage = "Phone Code cannot exceed 15 characters")]
    public string? PhoneNumber { get; set; }

    //[Column(TypeName = "TIME")]
    //[StringLength(5)]
    //[Column(TypeName = "varchar(5)")]
    [StringLength(10)]
    public string? OpeningTime { get; set; }

    //[Column(TypeName = "varchar(5)")]
    [StringLength(10)]
    public string? ClosingTime { get; set; }

    [MaxLength(500, ErrorMessage = "WebSite cannot exceed 500 characters")]
    public string? WebSite { get; set; }

    [Column(TypeName = "date")] public DateTime? RequestedDate { get; set; }

    public RequestStatusEnum? RequestStatus { get; set; }

    [Column(TypeName = "date")] public DateTime? ApprovedDate { get; set; }

    public Guid? ApprovalUserId { get; set; }

    [MaxLength(500, ErrorMessage = "Image cannot exceed 500 characters")]
    public string? Image { get; set; }

    [ForeignKey(nameof(Owner))] public Guid? OwnerId { get; set; }
    public Owner? Owner { get; set; }

    [ForeignKey(nameof(Category))] public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    [ForeignKey(nameof(User))] public string? UserId { get; set; }
    public User? User { get; set; }


    public ICollection<EstablishmentAccessibility>? EstablishmentsAccessibilitys { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}
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

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [MaxLength(15, ErrorMessage = "Phone Code cannot exceed 15 characters")]
    public string? PhoneNumber { get; set; }

    public string? WebSite { get; set; }

    [Column(TypeName = "date")] public DateTime? RequestedDate { get; set; }

    public RequestStatusEnum? RequestStatus { get; set; }

    [Column(TypeName = "date")] public DateTime? ApprovedDate { get; set; }

    public Guid? ApprovalUserId { get; set; }

    public string? Image { get; set; }

    [ForeignKey(nameof(Owner))] public Guid? OwnerId { get; set; }
    public Owner? Owner { get; set; }

    [ForeignKey(nameof(Category))] public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<Review>? Reviews { get; set; }
}
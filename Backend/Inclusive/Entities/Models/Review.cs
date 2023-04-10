using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Establishments;

namespace Entities.Models;

public class Review
{
    [Column("ReviewId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Rating is required")]
    [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
    public int? Rating { get; set; }

    [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
    public string? Comment { get; set; }


    [ForeignKey(nameof(Establishment))] public Guid? EstablishmentId { get; set; }
    public Establishment? Establishment { get; set; }


    [ForeignKey(nameof(User))] public string? UserId { get; set; }
    public User? User { get; set; }

    public DateTime Created { get; set; }
}
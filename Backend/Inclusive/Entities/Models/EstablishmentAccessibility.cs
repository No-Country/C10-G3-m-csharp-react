using Entities.Models;
using Entities.Models.Establishments;
using Entities.Models.Owners;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Entities.Models;

[Index(nameof(EstablishmentId), nameof(OrderNumber), IsUnique = true)]
public class EstablishmentAccessibility
{
    public Guid EstablishmentId { get; set; }
    public Guid AccessibilityId { get; set; }

    [MaxLength(50, ErrorMessage = "Accessibility Name must be less than 50 characters")]
    public string? AccessibilityName { get; set; }

    public int OrderNumber { get; set; }

    public Establishment? Establishment { get; set; }

    public Accessibility? Accessibility { get; set; }
}

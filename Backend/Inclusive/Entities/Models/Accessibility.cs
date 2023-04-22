using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

[Index(nameof(OrderNumber), IsUnique = true)]
public class Accessibility
{
    [Column("AccessibilityId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name must be less than 50 characters")]
    public string? Name { get; set; }
    public int OrderNumber { get; set; }
}

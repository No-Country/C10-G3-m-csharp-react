using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class CategoryImage
{
    [Column("CategoryImageId")] public Guid Id { get; set; }

    public string? ImageName { get; set; }
    public string? ImagePath { get; set; }

    [ForeignKey(nameof(Category))] public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Establishments;

namespace Entities.Models;

public class Category
{
    [Column("CategoryId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(60, ErrorMessage = "Name must be less than 60 characters")]
    public string? Name { get; set; }

    [MaxLength(255, ErrorMessage = "Description must be less than 255 characters")]
    public string? Description { get; set; }

    [MaxLength(500, ErrorMessage = "Image must be less than 500 characters")]
    public string? Image { get; set; }

    public ICollection<Establishment>? Establishments { get; set; }
}
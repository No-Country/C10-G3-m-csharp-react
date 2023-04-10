using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasData(
            new Review
            {
                Id = Guid.NewGuid(),
                Rating = 5,
                Comment = "Excelente accesibilidad y atencion en el local",
            }
        );
    }
}

using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        // Los usuarios q se van a crear por defecto van aca
        // Se crean los objetos de usuario
        builder.HasData(
            // Admin
            new User
            {
                Id = "D6C8B4EF-4926-472C-84B7-6BF2300CE8A5",
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com".ToUpperInvariant(),
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "Admin123!"),
                EmailConfirmed = true
            },
            new User
            {
                Id = "29516888-6214-4FBB-A20B-7509B07F25CD",
                Email = "juanperez@localhost.com",
                NormalizedEmail = "juanperez@localhost.com".ToUpperInvariant(),
                FirstName = "Juan",
                LastName = "Perez",
                UserName = "juanperez",
                NormalizedUserName = "juanperez".ToUpperInvariant(),
                PasswordHash = hasher.HashPassword(null, "Admin123!"),
                EmailConfirmed = true
            });
    }
}


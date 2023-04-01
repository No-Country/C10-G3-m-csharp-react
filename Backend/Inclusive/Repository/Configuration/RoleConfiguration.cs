using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Helper;

namespace Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
          // Admin
          new IdentityRole
          {
              Id = "A5051E62-875D-4169-B97B-5488F9EA54F2",
              Name = UserRoles.Administrator,
              NormalizedName = UserRoles.Administrator.ToUpperInvariant(),
          },
          // User
          new IdentityRole
          {
              Id = "A6EB18A6-5135-4951-8445-617BF404486A",
              Name = UserRoles.User,
              NormalizedName = UserRoles.User.ToUpperInvariant(),
          }
          );
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
         // Admin
         new IdentityUserRole<string>
         {
             RoleId = "A5051E62-875D-4169-B97B-5488F9EA54F2",
             UserId = "D6C8B4EF-4926-472C-84B7-6BF2300CE8A5"
         },
         new IdentityUserRole<string>
         {
             RoleId = "A6EB18A6-5135-4951-8445-617BF404486A",
             UserId = "29516888-6214-4FBB-A20B-7509B07F25CD"
         }
         );
    }
}


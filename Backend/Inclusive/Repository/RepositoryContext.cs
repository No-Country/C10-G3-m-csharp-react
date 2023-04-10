using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.Establishments;
using Entities.Models.Owners;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EstablishmentAccessibility>().HasKey(ea => new { ea.EstablishmentId, ea.AccessibilityId});

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new OwnerConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Establishment>? Establishments { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Accessibility> Accessibilitys { get; set; }
        public DbSet<EstablishmentAccessibility> EstablishmentsAccessibilitys { get; set; }
    }
}
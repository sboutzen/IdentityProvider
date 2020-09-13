using IdentityProviderCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityProviderInfrastructure.Contexts
{
    public class IdentityProviderDbContext : DbContext
    {
        public DbSet<EnterpriseUser> EnterpriseUsers { get; set; }

        public IdentityProviderDbContext(DbContextOptions<IdentityProviderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EnterpriseUser>().HasKey(c => c.Id).IsClustered(true);
            builder.Entity<EnterpriseUser>().HasKey(c => c.EntityId).IsClustered(false);
            builder.Entity<EnterpriseUser>().HasIndex(c => new { c.EntityId, c.UserId }).IsClustered(false);
            builder.Entity<EnterpriseUser>().HasData(
                new EnterpriseUser { Id = 1, EntityId = Guid.NewGuid(), UserId = Guid.NewGuid(), OrganizationName = "Org1" },
                new EnterpriseUser { Id = 2, EntityId = Guid.NewGuid(), UserId = Guid.NewGuid(), OrganizationName = "Org2" },
                new EnterpriseUser { Id = 3, EntityId = Guid.NewGuid(), UserId = Guid.NewGuid(), OrganizationName = "Org3" }
            );

            base.OnModelCreating(builder);
        }
    }
}

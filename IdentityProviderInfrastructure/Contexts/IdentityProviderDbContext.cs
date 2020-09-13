using IdentityProviderCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

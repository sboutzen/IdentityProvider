using IdentityProviderCore.Entities;
using IdentityProviderInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentityProviderInfrastructure.Contexts
{
    public class IdentityProviderDbContext : DbContext
    {
        const int MAX_COMMON_STRING_LENGTH = 256;
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        public IdentityProviderDbContext(DbContextOptions<IdentityProviderDbContext> options) : base(options)
        {

        }

        protected override async void OnModelCreating(ModelBuilder builder)
        {
            configureEntities(builder);
            await seed(builder);
            base.OnModelCreating(builder);
        }

        private async Task seed(ModelBuilder builder)
        {
            var entityBuilder = new IdentityProviderEntityBuilder();
            await seedClient(builder, entityBuilder);
            await seedUser(builder, entityBuilder);
            await seedEmail(builder, entityBuilder);
            await seedAccessToken(builder, entityBuilder);
        }

        private void configureEntities(ModelBuilder builder)
        {
            configureBaseEntity(builder);
            configureClientEntity(builder);
            configureUserEntity(builder);
            configureEmailEntity(builder);
            configureAccessTokenEntity(builder);
        }

        private void configureBaseEntity(ModelBuilder builder)
        {
            // TODO: Figure out how to do this with reflection instead.
            builder.ApplyConfiguration(new BaseEntityConfiguration<User>());
            builder.ApplyConfiguration(new BaseEntityConfiguration<Client>());
            builder.ApplyConfiguration(new BaseEntityConfiguration<Email>());
            builder.ApplyConfiguration(new BaseEntityConfiguration<AccessToken>());
        }

        private void configureClientEntity(ModelBuilder builder)
        {
            builder.Entity<Client>().Property(c => c.PhoneNumber).HasDefaultValueSql("null");
            builder.Entity<Client>().Property(c => c.PhoneNumber).HasMaxLength(MAX_COMMON_STRING_LENGTH);
        }

        private void configureUserEntity(ModelBuilder builder)
        {
            builder.Entity<User>().HasOne(e => e.Email).WithOne(e => e.User).HasForeignKey<Email>(e => e.UserId);
            builder.Entity<User>().Property(u => u.PasswordHash).HasMaxLength(512);
            builder.Entity<User>().Property(u => u.PasswordSalt).HasMaxLength(MAX_COMMON_STRING_LENGTH);
        }

        private void configureEmailEntity(ModelBuilder builder)
        {

        }

        private void configureAccessTokenEntity(ModelBuilder builder)
        {

        }

        private async Task seedClient(ModelBuilder builder, IdentityProviderEntityBuilder entityBuilder)
        {
            var clients = await entityBuilder.BuildClients();
            builder.Entity<Client>().HasData(clients);
        }

        private async Task seedUser(ModelBuilder builder, IdentityProviderEntityBuilder entityBuilder)
        {
            var users = await entityBuilder.BuildUsers();
            builder.Entity<User>().HasData(users);
        }

        private async Task seedEmail(ModelBuilder builder, IdentityProviderEntityBuilder entityBuilder)
        {
            var emails = await entityBuilder.BuildEmails();
            builder.Entity<Email>().HasData(emails);
        }

        private async Task seedAccessToken(ModelBuilder builder, IdentityProviderEntityBuilder entityBuilder)
        {
            var accessTokens = await entityBuilder.BuildAccessTokens();
            builder.Entity<AccessToken>().HasData(accessTokens);
        }
    }
}

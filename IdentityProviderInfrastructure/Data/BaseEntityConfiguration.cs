using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IdentityProviderInfrastructure.Contexts
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id").IsClustered(true);
            builder.HasAlternateKey("EntityId").IsClustered(false);
            builder.HasIndex("EntityId").IsClustered(false);
            builder.Property<int>("Id").ValueGeneratedOnAdd();
            builder.Property<DateTime>("UpdatedAt")
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");
            builder.Property<DateTime>("CreatedAt")
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");
        }
    }
}

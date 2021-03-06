﻿// <auto-generated />
using System;
using IdentityProviderInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityProviderInfrastructure.Migrations
{
    [DbContext(typeof(IdentityProviderDbContext))]
    [Migration("20200916143813_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.8.20407.4");

            modelBuilder.Entity("IdentityProviderCore.Entities.AccessToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Exhausted")
                        .HasColumnType("bit");

                    b.Property<bool>("LongLived")
                        .HasColumnType("bit");

                    b.Property<string>("Nonce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasAlternateKey("EntityId")
                        .IsClustered(false);

                    b.HasIndex("EntityId")
                        .IsClustered(false);

                    b.HasIndex("UserId");

                    b.ToTable("AccessToken");
                });

            modelBuilder.Entity("IdentityProviderCore.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Organization")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasDefaultValueSql("null");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasAlternateKey("EntityId")
                        .IsClustered(false);

                    b.HasIndex("EntityId")
                        .IsClustered(false);

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntityId = new Guid("9e7f2d2e-3d46-4eb7-8d05-91a5e1f0ce34"),
                            Organization = 0,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntityId = new Guid("9d6a0533-b737-40c9-ba4e-709805b5079c"),
                            Organization = 1,
                            PhoneNumber = "some phone number 2",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntityId = new Guid("08f99e27-f241-4acc-b4a0-6a31f7b5ce3c"),
                            Organization = 2,
                            PhoneNumber = "some phone number 3",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IdentityProviderCore.Entities.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasAlternateKey("EntityId")
                        .IsClustered(false);

                    b.HasIndex("EntityId")
                        .IsClustered(false);

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Email");
                });

            modelBuilder.Entity("IdentityProviderCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasAlternateKey("EntityId")
                        .IsClustered(false);

                    b.HasIndex("ClientId");

                    b.HasIndex("EntityId")
                        .IsClustered(false);

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntityId = new Guid("54652c6f-8157-4048-919c-628c8ea99b3b"),
                            IsAdmin = true,
                            PasswordHash = "hash1",
                            PasswordSalt = "salt1",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntityId = new Guid("1234bb34-9dda-4e8a-bab6-17db7ef30060"),
                            IsAdmin = true,
                            PasswordHash = "hash2",
                            PasswordSalt = "salt2",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EntityId = new Guid("7b832965-5494-4a5f-b2df-e8ff10d9358d"),
                            IsAdmin = false,
                            PasswordHash = "hash3",
                            PasswordSalt = "salt3",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IdentityProviderCore.Entities.AccessToken", b =>
                {
                    b.HasOne("IdentityProviderCore.Entities.User", "User")
                        .WithMany("AccessTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityProviderCore.Entities.Email", b =>
                {
                    b.HasOne("IdentityProviderCore.Entities.User", "User")
                        .WithOne("Email")
                        .HasForeignKey("IdentityProviderCore.Entities.Email", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityProviderCore.Entities.User", b =>
                {
                    b.HasOne("IdentityProviderCore.Entities.Client", "Client")
                        .WithMany("Users")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

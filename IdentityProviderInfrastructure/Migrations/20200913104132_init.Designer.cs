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
    [Migration("20200913104132_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.8.20407.4");

            modelBuilder.Entity("IdentityProviderCore.Entities.EnterpriseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("EntityId", "UserId")
                        .IsClustered(false);

                    b.ToTable("EnterpriseUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntityId = new Guid("fb055b80-816c-4a84-8570-ff07a0f86fc1"),
                            OrganizationName = "Org1",
                            UserId = new Guid("608dfa6a-ecb0-49f0-93d2-444f7a42759f")
                        },
                        new
                        {
                            Id = 2,
                            EntityId = new Guid("01373fc2-1d55-47ba-863d-34b5ec55251d"),
                            OrganizationName = "Org2",
                            UserId = new Guid("5621c4b0-4e8e-405c-a504-b5e0a8d98f1d")
                        },
                        new
                        {
                            Id = 3,
                            EntityId = new Guid("620d55ba-df92-4011-9b3e-c6c175893bee"),
                            OrganizationName = "Org3",
                            UserId = new Guid("1d2154d9-c514-4f07-8f3f-6da6cfd76514")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

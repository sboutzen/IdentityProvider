using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityProviderInfrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterpriseUsers",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseUsers", x => x.EntityId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "EntityId", "Id", "OrganizationName", "UserId" },
                values: new object[] { new Guid("86019bf7-27ce-4f9f-9b6c-e2f08608e063"), 1, "Org1", new Guid("4bd23529-22a1-4802-992d-d8b12c3dfc5f") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "EntityId", "Id", "OrganizationName", "UserId" },
                values: new object[] { new Guid("d027528c-77d8-4f1b-b3a6-79ee911f9760"), 2, "Org2", new Guid("5472e4ad-b07c-4bc4-a747-8784fedcf46d") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "EntityId", "Id", "OrganizationName", "UserId" },
                values: new object[] { new Guid("368e9465-da5c-41b0-895b-adcd85a6ffb8"), 3, "Org3", new Guid("6427fbbb-4464-459d-83f5-9333ae9ae475") });

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseUsers_EntityId_UserId",
                table: "EnterpriseUsers",
                columns: new[] { "EntityId", "UserId" })
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterpriseUsers");
        }
    }
}

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseUsers", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 1, new Guid("fb055b80-816c-4a84-8570-ff07a0f86fc1"), "Org1", new Guid("608dfa6a-ecb0-49f0-93d2-444f7a42759f") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 2, new Guid("01373fc2-1d55-47ba-863d-34b5ec55251d"), "Org2", new Guid("5621c4b0-4e8e-405c-a504-b5e0a8d98f1d") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 3, new Guid("620d55ba-df92-4011-9b3e-c6c175893bee"), "Org3", new Guid("1d2154d9-c514-4f07-8f3f-6da6cfd76514") });

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

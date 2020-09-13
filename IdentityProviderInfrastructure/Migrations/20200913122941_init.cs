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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseUsers", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_EnterpriseUsers_EntityId", x => x.EntityId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 1, new Guid("aeaf6f23-545c-4362-bfbc-c57eacdf0432"), "Org1", new Guid("dbbb2de7-6cc8-4082-a806-b43fa2c86761") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 2, new Guid("5e9aaccd-2b9d-4d4c-866d-5e47bf18ac3c"), "Org2", new Guid("49eb5860-a585-48fb-8fab-63e6846e65ee") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 3, new Guid("76a48b70-ec46-4b77-a348-90a2534a1a54"), "Org3", new Guid("12080cd2-5fbd-444a-925f-f40d32f42f4c") });

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

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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
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
                values: new object[] { 1, new Guid("2a439e8a-5745-4d53-adde-c1d79be32380"), "Org1", new Guid("44466c7e-e22f-46a2-b4b5-57ea8a1b8da9") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 2, new Guid("26912c96-6105-46e1-9ab2-da64c49d308b"), "Org2", new Guid("7a84eb42-4113-4135-80f4-645294180550") });

            migrationBuilder.InsertData(
                table: "EnterpriseUsers",
                columns: new[] { "Id", "EntityId", "OrganizationName", "UserId" },
                values: new object[] { 3, new Guid("bcacae8b-20e1-4425-96fe-1a1397102b0d"), "Org3", new Guid("77432a6b-6cb8-4a87-a26c-e33fe822b068") });

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

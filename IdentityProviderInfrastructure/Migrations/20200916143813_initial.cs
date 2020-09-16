using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IdentityProviderInfrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Organization = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, defaultValueSql: "null")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Clients_EntityId", x => x.EntityId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Users_EntityId", x => x.EntityId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Users_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exhausted = table.Column<bool>(type: "bit", nullable: false),
                    LongLived = table.Column<bool>(type: "bit", nullable: false),
                    TokenExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nonce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessToken", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_AccessToken_EntityId", x => x.EntityId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_AccessToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Email_EntityId", x => x.EntityId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Email_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "EntityId", "Organization" },
                values: new object[] { 1, new Guid("9e7f2d2e-3d46-4eb7-8d05-91a5e1f0ce34"), 0 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "EntityId", "Organization", "PhoneNumber" },
                values: new object[] { 2, new Guid("9d6a0533-b737-40c9-ba4e-709805b5079c"), 1, "some phone number 2" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "EntityId", "Organization", "PhoneNumber" },
                values: new object[] { 3, new Guid("08f99e27-f241-4acc-b4a0-6a31f7b5ce3c"), 2, "some phone number 3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ClientId", "EntityId", "IsAdmin", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, 1, new Guid("54652c6f-8157-4048-919c-628c8ea99b3b"), true, "hash1", "salt1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ClientId", "EntityId", "IsAdmin", "PasswordHash", "PasswordSalt" },
                values: new object[] { 2, 2, new Guid("1234bb34-9dda-4e8a-bab6-17db7ef30060"), true, "hash2", "salt2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ClientId", "EntityId", "IsAdmin", "PasswordHash", "PasswordSalt" },
                values: new object[] { 3, 3, new Guid("7b832965-5494-4a5f-b2df-e8ff10d9358d"), false, "hash3", "salt3" });

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_EntityId",
                table: "AccessToken",
                column: "EntityId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_UserId",
                table: "AccessToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EntityId",
                table: "Clients",
                column: "EntityId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Email_EntityId",
                table: "Email",
                column: "EntityId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Email_UserId",
                table: "Email",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientId",
                table: "Users",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EntityId",
                table: "Users",
                column: "EntityId")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AltTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    BaseIncomePerSecond = table.Column<decimal>(type: "numeric", nullable: false),
                    BaseUpgradePrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    LastIncomeAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClickLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAlts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AltTypeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAlts", x => new { x.UserId, x.AltTypeId });
                    table.ForeignKey(
                        name: "FK_UserAlts_AltTypes_AltTypeId",
                        column: x => x.AltTypeId,
                        principalTable: "AltTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAlts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AltTypes",
                columns: new[] { "Id", "BaseIncomePerSecond", "BaseUpgradePrice", "BuyPrice", "Name", "Rank" },
                values: new object[,]
                {
                    { 1, 1m, 10m, 0m, "Student", 1 },
                    { 2, 5m, 50m, 100m, "Activist", 2 },
                    { 3, 25m, 250m, 500m, "Deputy", 3 },
                    { 4, 150m, 1000m, 2500m, "Minister", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltTypes_Rank",
                table: "AltTypes",
                column: "Rank",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAlts_AltTypeId",
                table: "UserAlts",
                column: "AltTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAlts");

            migrationBuilder.DropTable(
                name: "AltTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

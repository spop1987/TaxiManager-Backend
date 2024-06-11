using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiManagerInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "dateTime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DriverLicense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Category = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpeditionDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "dateTime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "dateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverLicense_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicense_UserId",
                table: "DriverLicense",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverLicense");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "User");
        }
    }
}

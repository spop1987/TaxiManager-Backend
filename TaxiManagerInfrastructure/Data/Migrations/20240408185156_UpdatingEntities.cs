using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiManagerInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Drivers_DriverId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DriverId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DriverId",
                table: "Addresses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VehicleId",
                table: "Drivers",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Drivers_DriverId",
                table: "Addresses",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiManagerInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "dateTime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "dateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Registration = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Brand = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Model = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Year = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    Nickname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "dateTime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "dateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "dateTime", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Driver",
                        column: x => x.DriverId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleMileage = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    IsRepair = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPrice_Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    LaborPrice_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborPrice_Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutoPartName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price_Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    MaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoPart_Maintenance_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Zipcode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AutoPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "dateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "dateTime", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "dateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AutoPart_AutoPartId",
                        column: x => x.AutoPartId,
                        principalTable: "AutoPart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Maintenance_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenance",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AutoPartId",
                table: "Address",
                column: "AutoPartId",
                unique: true,
                filter: "[AutoPartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_MaintenanceId",
                table: "Address",
                column: "MaintenanceId",
                unique: true,
                filter: "[MaintenanceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoPart_MaintenanceId",
                table: "AutoPart",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_DriverId",
                table: "Enrollment",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_VehicleId",
                table: "Enrollment",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_VehicleId",
                table: "Maintenance",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_NationalId",
                table: "User",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Registration",
                table: "Vehicle",
                column: "Registration",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "AutoPart");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}

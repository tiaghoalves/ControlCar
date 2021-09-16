using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCar.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    IdAuthentication = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_autentication", x => x.IdAuthentication)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    IdDriver = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Cpf = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    ExpirationDateCnh = table.Column<DateTime>(type: "datetime", nullable: false),
                    Office = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Cellphone = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    TypeDriver = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sector = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Rg = table.Column<string>(unicode: false, maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Driver", x => x.IdDriver)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    IdMaintenance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Frequency = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maintenance", x => x.IdMaintenance)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    IdRoute = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Destiny = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    KmPattern = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Route", x => x.IdRoute)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "StatusScheduling",
                columns: table => new
                {
                    IdstatusScheduling = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status_Scheduling", x => x.IdstatusScheduling)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "StatusVehicle",
                columns: table => new
                {
                    IdstatusVehicle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status_vehicle", x => x.IdstatusVehicle)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    IdVehicle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Km = table.Column<double>(nullable: false),
                    Board = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Type = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Brand = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Color = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Renavam = table.Column<int>(type: "int", nullable: false),
                    Chassi = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IdStatusVehicle = table.Column<int>(nullable: true),
                    Observation = table.Column<string>(unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Vehicle", x => x.IdVehicle)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "fk_Vehicle_statusVehicle",
                        column: x => x.IdStatusVehicle,
                        principalTable: "StatusVehicle",
                        principalColumn: "IdstatusVehicle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scheduling",
                columns: table => new
                {
                    IdScheduling = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdRoute = table.Column<int>(nullable: true),
                    IdVehicle = table.Column<int>(nullable: true),
                    IdDriver = table.Column<int>(nullable: true),
                    StartDatePerformed = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDatePerformed = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndKm = table.Column<double>(nullable: true),
                    IdStatusScheduling = table.Column<int>(nullable: true),
                    IdAuthentication = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Scheduling", x => x.IdScheduling)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "fk_Scheduling_Driver",
                        column: x => x.IdDriver,
                        principalTable: "Driver",
                        principalColumn: "IdDriver",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Scheduling_Route",
                        column: x => x.IdRoute,
                        principalTable: "Route",
                        principalColumn: "IdRoute",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Scheduling_authentication",
                        column: x => x.IdScheduling,
                        principalTable: "Authentication",
                        principalColumn: "IdAuthentication",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "fk_Scheduling_status_Scheduling",
                        column: x => x.IdStatusScheduling,
                        principalTable: "StatusScheduling",
                        principalColumn: "IdstatusScheduling",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Scheduling_Vehicle",
                        column: x => x.IdVehicle,
                        principalTable: "Vehicle",
                        principalColumn: "IdVehicle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMaintenance",
                columns: table => new
                {
                    IdVehicleMaintenance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVehicle = table.Column<int>(nullable: false),
                    IdMaintenance = table.Column<int>(nullable: false),
                    DateMaintenance = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_veicmanu", x => x.IdVehicleMaintenance)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "fk_veicmanu_maintenance",
                        column: x => x.IdMaintenance,
                        principalTable: "Maintenance",
                        principalColumn: "IdMaintenance",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_veicmanu_Vehicle",
                        column: x => x.IdVehicle,
                        principalTable: "Vehicle",
                        principalColumn: "IdVehicle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdDriver",
                table: "Scheduling",
                column: "IdDriver");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdRoute",
                table: "Scheduling",
                column: "IdRoute");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdStatusScheduling",
                table: "Scheduling",
                column: "IdStatusScheduling");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdVehicle",
                table: "Scheduling",
                column: "IdVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_IdStatusVehicle",
                table: "Vehicle",
                column: "IdStatusVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenance_IdMaintenance",
                table: "VehicleMaintenance",
                column: "IdMaintenance");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenance_IdVehicle",
                table: "VehicleMaintenance",
                column: "IdVehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scheduling");

            migrationBuilder.DropTable(
                name: "VehicleMaintenance");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropTable(
                name: "StatusScheduling");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "StatusVehicle");
        }
    }
}

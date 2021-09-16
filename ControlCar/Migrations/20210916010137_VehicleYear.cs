using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ControlCar.Migrations
{
    public partial class VehicleYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicle",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "Renavam",
                table: "Vehicle",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Renavam",
                table: "Vehicle",
                type: "numeric(18, 0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCADA_backend.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ScanTime",
                table: "DigitalInputs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScanTime",
                table: "AnalogInputs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ScanTime",
                table: "DigitalInputs",
                type: "double",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "ScanTime",
                table: "AnalogInputs",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}

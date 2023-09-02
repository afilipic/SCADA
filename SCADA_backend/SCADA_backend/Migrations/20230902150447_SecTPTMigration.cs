using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCADA_backend.Migrations
{
    /// <inheritdoc />
    public partial class SecTPTMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "DigitalOutputs",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<double>(
                name: "InitialValue",
                table: "DigitalOutputs",
                type: "double",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Value",
                table: "DigitalOutputs",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<bool>(
                name: "InitialValue",
                table: "DigitalOutputs",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}

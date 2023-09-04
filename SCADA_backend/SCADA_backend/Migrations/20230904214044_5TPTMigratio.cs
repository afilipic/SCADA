using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCADA_backend.Migrations
{
    /// <inheritdoc />
    public partial class _5TPTMigratio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_AnalogInputs_AnalogInputId",
                table: "Alarms");

            migrationBuilder.DropColumn(
                name: "AITagId",
                table: "Alarms");

            migrationBuilder.UpdateData(
                table: "Alarms",
                keyColumn: "AnalogInputId",
                keyValue: null,
                column: "AnalogInputId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AnalogInputId",
                table: "Alarms",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_AnalogInputs_AnalogInputId",
                table: "Alarms",
                column: "AnalogInputId",
                principalTable: "AnalogInputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_AnalogInputs_AnalogInputId",
                table: "Alarms");

            migrationBuilder.AlterColumn<string>(
                name: "AnalogInputId",
                table: "Alarms",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AITagId",
                table: "Alarms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_AnalogInputs_AnalogInputId",
                table: "Alarms",
                column: "AnalogInputId",
                principalTable: "AnalogInputs",
                principalColumn: "Id");
        }
    }
}

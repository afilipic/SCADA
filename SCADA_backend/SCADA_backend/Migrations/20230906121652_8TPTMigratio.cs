using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCADA_backend.Migrations
{
    /// <inheritdoc />
    public partial class _8TPTMigratio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_AnalogInputs_AnalogInputId",
                table: "Alarms");

            migrationBuilder.DropIndex(
                name: "IX_Alarms_AnalogInputId",
                table: "Alarms");

            migrationBuilder.AlterColumn<string>(
                name: "AnalogInputId",
                table: "Alarms",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnalogInputId",
                table: "Alarms",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_AnalogInputId",
                table: "Alarms",
                column: "AnalogInputId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_AnalogInputs_AnalogInputId",
                table: "Alarms",
                column: "AnalogInputId",
                principalTable: "AnalogInputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

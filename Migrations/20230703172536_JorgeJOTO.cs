using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class JorgeJOTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JorgieJOTO",
                table: "Tarea",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de01"),
                columns: new[] { "FechaCreacion", "JorgieJOTO" },
                values: new object[] { new DateTime(2023, 7, 3, 11, 25, 36, 125, DateTimeKind.Local).AddTicks(8440), true });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de02"),
                columns: new[] { "FechaCreacion", "JorgieJOTO" },
                values: new object[] { new DateTime(2023, 7, 3, 11, 25, 36, 125, DateTimeKind.Local).AddTicks(8457), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JorgieJOTO",
                table: "Tarea");

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de01"),
                column: "FechaCreacion",
                value: new DateTime(2023, 7, 2, 23, 41, 14, 108, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de02"),
                column: "FechaCreacion",
                value: new DateTime(2023, 7, 2, 23, 41, 14, 108, DateTimeKind.Local).AddTicks(4648));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tarea",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("adb3e939-67a7-4823-bed3-00825062de30"), null, "Personales", 20 },
                    { new Guid("adb3e939-67a7-4823-bed3-00825062de31"), null, "Trabajo", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "FechaCreacion", "PrioridadTarea", "Titulo", "descripcion" },
                values: new object[,]
                {
                    { new Guid("adb3e939-67a7-4823-bed3-00825062de01"), new Guid("adb3e939-67a7-4823-bed3-00825062de30"), new DateTime(2023, 7, 2, 23, 41, 14, 108, DateTimeKind.Local).AddTicks(4625), 2, "Revision Cadera", null },
                    { new Guid("adb3e939-67a7-4823-bed3-00825062de02"), new Guid("adb3e939-67a7-4823-bed3-00825062de31"), new DateTime(2023, 7, 2, 23, 41, 14, 108, DateTimeKind.Local).AddTicks(4648), 2, "Terminar Presentacion Flx", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de01"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de30"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("adb3e939-67a7-4823-bed3-00825062de31"));

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tarea",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }
    }
}

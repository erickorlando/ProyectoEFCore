using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEFCore.AccesoDatos.Migrations
{
    public partial class DivisionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinRodaje",
                table: "Pelicula",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioRodaje",
                table: "Pelicula",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NombreDirector",
                table: "Pelicula",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreProductor",
                table: "Pelicula",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PresupuestoInicial",
                table: "Pelicula",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinRodaje",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "FechaInicioRodaje",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "NombreDirector",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "NombreProductor",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "PresupuestoInicial",
                table: "Pelicula");
        }
    }
}

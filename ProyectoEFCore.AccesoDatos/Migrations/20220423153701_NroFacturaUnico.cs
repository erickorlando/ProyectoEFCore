using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEFCore.AccesoDatos.Migrations
{
    public partial class NroFacturaUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroFactura",
                table: "Ticket",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_NumeroFactura",
                table: "Ticket",
                column: "NumeroFactura",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_NumeroFactura",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NumeroFactura",
                table: "Ticket");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEFCore.AccesoDatos.Migrations
{
    public partial class RelacionTicketCine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CineFk",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeliculaIdFk",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CineFk",
                table: "Ticket",
                column: "CineFk");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PeliculaIdFk",
                table: "Ticket",
                column: "PeliculaIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Cine_CineFk",
                table: "Ticket",
                column: "CineFk",
                principalTable: "Cine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Pelicula_PeliculaIdFk",
                table: "Ticket",
                column: "PeliculaIdFk",
                principalTable: "Pelicula",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Cine_CineFk",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Pelicula_PeliculaIdFk",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CineFk",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_PeliculaIdFk",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CineFk",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PeliculaIdFk",
                table: "Ticket");
        }
    }
}

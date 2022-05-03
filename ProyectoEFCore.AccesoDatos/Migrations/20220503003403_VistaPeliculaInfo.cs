using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEFCore.AccesoDatos.Migrations
{
    public partial class VistaPeliculaInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.PeliculaInfo AS
SELECT 
	P.Id, P.NombrePelicula, COUNT(CP.Id) CantidadCines  
FROM Pelicula P
INNER JOIN CinePeliculas CP ON CP.PeliculaId = CP.PeliculaId
AND CP.EnCartelera = 1
WHERE P.[Status] = 1
GROUP BY P.ID, P.NombrePelicula
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop VIEW dbo.PeliculaInfo");
        }
    }
}

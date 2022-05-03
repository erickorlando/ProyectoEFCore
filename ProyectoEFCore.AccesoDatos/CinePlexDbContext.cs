using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos
{
    public class CinePlexDbContext : DbContext
    {
        public CinePlexDbContext()
        {

        }

        public CinePlexDbContext(DbContextOptions<CinePlexDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Escanear el ensamblado entero en busqueda del IEntityTypeConfiguration

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Aplicar un configuration Individual

            //modelBuilder.ApplyConfiguration(new SalaConfiguration());

            modelBuilder.Ignore<TicketInfo>();

            modelBuilder.Ignore<PeliculaInfo>();

//            var query = @"SELECT 
//	P.Id, P.NombrePelicula, COUNT(CP.Id) CantidadCines  
//FROM Peliculas P
//INNER JOIN CinePeliculas CP ON CP.PeliculaId = CP.PeliculaId
//AND CP.EnCartelera = 1
//WHERE P.[Status] = 1
//GROUP BY P.ID, P.NombrePelicula";

            modelBuilder.Entity<PeliculaInfo>()
                .HasNoKey()
                .ToView("PeliculaInfo");
        }
    }
}
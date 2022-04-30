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

        }
    }
}
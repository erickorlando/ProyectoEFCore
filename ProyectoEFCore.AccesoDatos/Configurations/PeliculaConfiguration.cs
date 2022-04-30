using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
{
    public void Configure(EntityTypeBuilder<Pelicula> builder)
    {
        builder.Property(p => p.NombrePelicula)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(p => p.PaisOrigen)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.FechaEstreno)
            .HasColumnType("date")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.Sinopsis)
            .HasMaxLength(1000);

        builder.HasOne(p => p.PeliculaDetalle)
            .WithOne(x => x.Pelicula)
            .HasForeignKey<PeliculaDetalle>(p => p.Id);

        builder.HasQueryFilter(p => p.Status);
    }
}
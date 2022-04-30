using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class CinePeliculasConfiguration : IEntityTypeConfiguration<CinePeliculas>
{
    public void Configure(EntityTypeBuilder<CinePeliculas> builder)
    {
        builder.HasOne(p => p.Cine)
            .WithMany(p => p.CinePeliculas)
            .HasForeignKey(p => p.CineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Pelicula)
            .WithMany(p => p.CinePeliculas)
            .HasForeignKey(p => p.PeliculaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
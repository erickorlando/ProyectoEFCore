using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class PeliculaDetalleConfiguration : IEntityTypeConfiguration<PeliculaDetalle>
{
    public void Configure(EntityTypeBuilder<PeliculaDetalle> builder)
    {
        builder.ToTable("Pelicula");
    }
}
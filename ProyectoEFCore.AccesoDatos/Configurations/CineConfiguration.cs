using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class CineConfiguration : IEntityTypeConfiguration<Cine>
{
    public void Configure(EntityTypeBuilder<Cine> builder)
    {
        builder.Property(p => p.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Direccion)
            .HasMaxLength(200)
            .IsRequired();
    }
}
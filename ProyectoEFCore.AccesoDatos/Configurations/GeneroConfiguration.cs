using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder
            .Property(p => p.NombreGenero)
            .HasMaxLength(50)
            .IsRequired();
    }
}
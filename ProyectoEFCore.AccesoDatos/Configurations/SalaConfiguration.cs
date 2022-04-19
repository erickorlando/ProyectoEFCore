using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class SalaConfiguration : IEntityTypeConfiguration<Sala>
{
    public void Configure(EntityTypeBuilder<Sala> builder)
    {

        // NVARCHAR = UNICODE 
        // VARCHAR = ASCII

        builder
            .Property(p => p.NombreSala)
            .IsUnicode(false)
            .HasMaxLength(10)
            .IsRequired();

        builder
            .Property(p => p.TipoSala)
            .IsRequired()
            .HasDefaultValue(EnumTipoSala.Sala3D);
    }
}
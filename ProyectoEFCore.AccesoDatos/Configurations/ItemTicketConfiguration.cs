using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class ItemTicketConfiguration : IEntityTypeConfiguration<ItemTicket>
{
    public void Configure(EntityTypeBuilder<ItemTicket> builder)
    {
        builder.Property(p => p.NroAsiento)
            .IsUnicode(false)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(p => p.PrecioUnitario)
            .HasPrecision(8, 2);

        builder.Property(p => p.TipoAsiento)
            .HasDefaultValue(TipoAsiento.Generico);
    }
}
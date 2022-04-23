using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class TicketInfoConfiguration : IEntityTypeConfiguration<TicketInfo>
{
    public void Configure(EntityTypeBuilder<TicketInfo> builder)
    {
        builder.HasNoKey();
        builder.Property(p => p.Total)
            .HasPrecision(8, 2);
    }
}
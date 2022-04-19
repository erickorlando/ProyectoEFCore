﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(p => p.Cliente)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.FechaVenta)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.Cantidad)
            .HasColumnType("tinyint")
            .HasDefaultValue(1);

        builder.Property(p => p.PrecioTotal)
            .HasPrecision(8, 2);
    }
}
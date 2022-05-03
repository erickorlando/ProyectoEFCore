using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(p => p.Nombre)
            .HasMaxLength(100);

        builder.Property(p => p.CodigoSku)
            .HasMaxLength(13);

        builder.Property(p => p.PrecioUnitario)
            .HasPrecision(8,2);

        builder.HasDiscriminator(p => p.TipoProducto)
            .HasValue<ProductoMerchandising>(TipoProducto.Merchandising)
            .HasValue<ProductoServicio>(TipoProducto.Servicio);
    }
}
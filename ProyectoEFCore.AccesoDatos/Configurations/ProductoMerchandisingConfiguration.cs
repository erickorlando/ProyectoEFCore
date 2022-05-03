using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class ProductoMerchandisingConfiguration : IEntityTypeConfiguration<ProductoMerchandising>
{
    public void Configure(EntityTypeBuilder<ProductoMerchandising> builder)
    {
        builder.Property(p => p.DescripcionPromocion)
            .HasMaxLength(100);

        builder.HasData(new List<ProductoMerchandising>
        {
            new ProductoMerchandising
            {
                Id = 1,
                Nombre = "Camiseta",
                CantidadSaldo = 10,
                CodigoSku = "0349594693",
                ConExistencias = true,
                DescripcionPromocion = "PROMO 1",
                PrecioUnitario = 15.5m,
            },
            new ProductoMerchandising
            {
                Id = 2,
                Nombre = "Vaso de 16oz",
                CantidadSaldo = 25,
                CodigoSku = "03480484",
                ConExistencias = true,
                DescripcionPromocion = "PROMO 2",
                PrecioUnitario = 21.9m,
            },
        });
    }
}
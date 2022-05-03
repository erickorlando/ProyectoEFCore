using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.AccesoDatos.Configurations;

public class ProductoServicioConfiguration : IEntityTypeConfiguration<ProductoServicio>
{
    public void Configure(EntityTypeBuilder<ProductoServicio> builder)
    {
        builder.Property(p => p.FechaServicio)
            .HasColumnType("DATE")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.Observaciones)
            .HasMaxLength(500);

        builder.HasData(new List<ProductoServicio>
        {
            new ProductoServicio
            {
                Id = 3,
                CodigoSku = "DERG453455",
                Nombre = "Alquiler de local",
                Observaciones = "Deja en adelanto $20",
                PrecioUnitario = 2999.99m,
            },
            new ProductoServicio
            {
                Id = 4,
                CodigoSku = "XAFG453455",
                Nombre = "Compra de entradas en estreno",
                Observaciones = "Pelicula nueva en 4K",
                PrecioUnitario = 36.80m,
            },
            new ProductoServicio
            {
                Id = 5,
                CodigoSku = "WUB46455",
                Nombre = "XXXXX",
                Observaciones = "",
                PrecioUnitario = 1.99m,
            },
        });
    }
}
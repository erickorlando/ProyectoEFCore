using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEFCore.AccesoDatos.Migrations
{
    public partial class Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    CodigoSku = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    TipoProducto = table.Column<int>(type: "int", nullable: false),
                    CantidadSaldo = table.Column<int>(type: "int", nullable: true),
                    ConExistencias = table.Column<bool>(type: "bit", nullable: true),
                    DescripcionPromocion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaServicio = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "GETDATE()"),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "CantidadSaldo", "CodigoSku", "ConExistencias", "DescripcionPromocion", "Nombre", "PrecioUnitario", "Status", "TipoProducto" },
                values: new object[,]
                {
                    { 1, 10, "0349594693", true, "PROMO 1", "Camiseta", 15.5m, true, 1 },
                    { 2, 25, "03480484", true, "PROMO 2", "Vaso de 16oz", 21.9m, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "CodigoSku", "Nombre", "Observaciones", "PrecioUnitario", "Status", "TipoProducto" },
                values: new object[,]
                {
                    { 3, "DERG453455", "Alquiler de local", "Deja en adelanto $20", 2999.99m, true, 0 },
                    { 4, "XAFG453455", "Compra de entradas en estreno", "Pelicula nueva en 4K", 36.80m, true, 0 },
                    { 5, "WUB46455", "XXXXX", "", 1.99m, true, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}

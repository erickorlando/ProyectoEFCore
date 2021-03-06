// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoEFCore.AccesoDatos;

#nullable disable

namespace ProyectoEFCore.AccesoDatos.Migrations
{
    [DbContext(typeof(CinePlexDbContext))]
    partial class CinePlexDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.HasKey("GenerosId", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("GeneroPelicula");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Cine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cine");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.CinePeliculas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CineId")
                        .HasColumnType("int");

                    b.Property<bool>("EnCartelera")
                        .HasColumnType("bit");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("CinePeliculas");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NombreGenero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.ItemTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NroAsiento")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("TipoAsiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("ItemTicket");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaEstreno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("NombrePelicula")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PaisOrigen")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Sinopsis")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.PeliculaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFinRodaje")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioRodaje")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreDirector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProductor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PresupuestoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pelicula", (string)null);
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.PeliculaInfo", b =>
                {
                    b.Property<int>("CantidadCines")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NombrePelicula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("PeliculaInfo");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodigoSku")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TipoProducto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Producto");

                    b.HasDiscriminator<int>("TipoProducto");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CineId")
                        .HasColumnType("int");

                    b.Property<string>("NombreSala")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TipoSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("Cantidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.Property<int>("CineFk")
                        .HasColumnType("int");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("NumeroFactura")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("PeliculaIdFk")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioTotal")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CineFk");

                    b.HasIndex("NumeroFactura")
                        .IsUnique();

                    b.HasIndex("PeliculaIdFk");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.ProductoMerchandising", b =>
                {
                    b.HasBaseType("ProyectoEFCore.Entidades.Producto");

                    b.Property<int>("CantidadSaldo")
                        .HasColumnType("int");

                    b.Property<bool>("ConExistencias")
                        .HasColumnType("bit");

                    b.Property<string>("DescripcionPromocion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodigoSku = "0349594693",
                            Nombre = "Camiseta",
                            PrecioUnitario = 15.5m,
                            Status = true,
                            TipoProducto = 0,
                            CantidadSaldo = 10,
                            ConExistencias = true,
                            DescripcionPromocion = "PROMO 1"
                        },
                        new
                        {
                            Id = 2,
                            CodigoSku = "03480484",
                            Nombre = "Vaso de 16oz",
                            PrecioUnitario = 21.9m,
                            Status = true,
                            TipoProducto = 0,
                            CantidadSaldo = 25,
                            ConExistencias = true,
                            DescripcionPromocion = "PROMO 2"
                        });
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.ProductoServicio", b =>
                {
                    b.HasBaseType("ProyectoEFCore.Entidades.Producto");

                    b.Property<DateTime?>("FechaServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasDiscriminator().HasValue(0);

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CodigoSku = "DERG453455",
                            Nombre = "Alquiler de local",
                            PrecioUnitario = 2999.99m,
                            Status = true,
                            TipoProducto = 0,
                            Observaciones = "Deja en adelanto $20"
                        },
                        new
                        {
                            Id = 4,
                            CodigoSku = "XAFG453455",
                            Nombre = "Compra de entradas en estreno",
                            PrecioUnitario = 36.80m,
                            Status = true,
                            TipoProducto = 0,
                            Observaciones = "Pelicula nueva en 4K"
                        },
                        new
                        {
                            Id = 5,
                            CodigoSku = "WUB46455",
                            Nombre = "XXXXX",
                            PrecioUnitario = 1.99m,
                            Status = true,
                            TipoProducto = 0,
                            Observaciones = ""
                        });
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoEFCore.Entidades.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.CinePeliculas", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Cine", "Cine")
                        .WithMany("CinePeliculas")
                        .HasForeignKey("CineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoEFCore.Entidades.Pelicula", "Pelicula")
                        .WithMany("CinePeliculas")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cine");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.ItemTicket", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.PeliculaDetalle", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Pelicula", "Pelicula")
                        .WithOne("PeliculaDetalle")
                        .HasForeignKey("ProyectoEFCore.Entidades.PeliculaDetalle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Sala", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Cine", "Cine")
                        .WithMany("Salas")
                        .HasForeignKey("CineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cine");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Ticket", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Cine", "Cine")
                        .WithMany()
                        .HasForeignKey("CineFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoEFCore.Entidades.Pelicula", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaIdFk")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Cine");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Cine", b =>
                {
                    b.Navigation("CinePeliculas");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("ProyectoEFCore.Entidades.Pelicula", b =>
                {
                    b.Navigation("CinePeliculas");

                    b.Navigation("PeliculaDetalle")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

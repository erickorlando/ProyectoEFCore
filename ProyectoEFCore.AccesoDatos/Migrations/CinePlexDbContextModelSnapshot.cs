﻿// <auto-generated />
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

                    b.ToTable("GeneroPelicula", (string)null);
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

                    b.ToTable("Cine", (string)null);
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

                    b.ToTable("Genero", (string)null);
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

                    b.ToTable("ItemTicket", (string)null);
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

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pelicula", (string)null);
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

                    b.ToTable("Sala", (string)null);
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

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<decimal>("PrecioTotal")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Ticket", (string)null);
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

            modelBuilder.Entity("ProyectoEFCore.Entidades.ItemTicket", b =>
                {
                    b.HasOne("ProyectoEFCore.Entidades.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
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

            modelBuilder.Entity("ProyectoEFCore.Entidades.Cine", b =>
                {
                    b.Navigation("Salas");
                });
#pragma warning restore 612, 618
        }
    }
}

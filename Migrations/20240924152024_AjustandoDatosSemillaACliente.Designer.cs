﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backNegocio.DataContext;

#nullable disable

namespace backNegocio.Migrations
{
    [DbContext(typeof(NegocioContext))]
    [Migration("20240924152024_AjustandoDatosSemillaACliente")]
    partial class AjustandoDatosSemillaACliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backNegocio.Models.Commons.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("apellidoNombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cuitDni")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CodigoPostal = "3040",
                            Localidad = "San Justo",
                            Provincia = "Santa Fe",
                            apellidoNombre = "Porchietto Ezequiel Gustavo",
                            cuitDni = "25730663",
                            direccion = " Juan Mantovani 1877",
                            eliminado = false,
                            email = "ezeporche@gmail.com",
                            telefono = "3498 431264"
                        },
                        new
                        {
                            id = 2,
                            CodigoPostal = "3048",
                            Localidad = "Videla",
                            Provincia = "Santa Fe",
                            apellidoNombre = "Perez Camila",
                            cuitDni = "33258369",
                            direccion = "Calle 31 324 ",
                            eliminado = false,
                            email = "camiperez@gamil.com",
                            telefono = "3498 452385"
                        });
                });

            modelBuilder.Entity("backNegocio.Models.Commons.Empleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellidoNombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("Empleado");

                    b.HasData(
                        new
                        {
                            id = 1,
                            apellidoNombre = "Gomez Juan",
                            dni = "12345678",
                            eliminado = false
                        },
                        new
                        {
                            id = 2,
                            apellidoNombre = "Cantero Maria",
                            dni = "87654321",
                            eliminado = false
                        });
                });

            modelBuilder.Entity("backNegocio.Models.Commons.Impresion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("descuento10")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("descuento20")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("descuento50")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("precioBase")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("tamanio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Impresion");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descuento10 = 0.10m,
                            descuento20 = 0.20m,
                            descuento50 = 0.50m,
                            eliminado = false,
                            precioBase = 800m,
                            tamanio = "7x10"
                        },
                        new
                        {
                            id = 2,
                            descuento10 = 0.10m,
                            descuento20 = 0.20m,
                            descuento50 = 0.50m,
                            eliminado = false,
                            precioBase = 1000m,
                            tamanio = "10x15"
                        },
                        new
                        {
                            id = 3,
                            descuento10 = 0.10m,
                            descuento20 = 0.20m,
                            descuento50 = 0.50m,
                            eliminado = false,
                            precioBase = 1500m,
                            tamanio = "13x18"
                        },
                        new
                        {
                            id = 4,
                            descuento10 = 0.10m,
                            descuento20 = 0.20m,
                            descuento50 = 0.50m,
                            eliminado = false,
                            precioBase = 2000m,
                            tamanio = "15x21"
                        });
                });

            modelBuilder.Entity("backNegocio.Models.Commons.ModoPago", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("ajuste")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("ModoPago");

                    b.HasData(
                        new
                        {
                            id = 1,
                            ajuste = -0.5m,
                            eliminado = false,
                            nombre = "efectivo"
                        },
                        new
                        {
                            id = 2,
                            ajuste = 0m,
                            eliminado = false,
                            nombre = "débito"
                        },
                        new
                        {
                            id = 3,
                            ajuste = 0m,
                            eliminado = false,
                            nombre = "crédito"
                        },
                        new
                        {
                            id = 4,
                            ajuste = -0.5m,
                            eliminado = false,
                            nombre = "transferencia"
                        });
                });

            modelBuilder.Entity("backNegocio.Models.Commons.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Rubro")
                        .HasColumnType("int");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Rubro = 4,
                            eliminado = false,
                            nombre = "Auricular inalámbrico F9",
                            precio = 13500m,
                            stock = 100
                        },
                        new
                        {
                            id = 2,
                            Rubro = 0,
                            eliminado = false,
                            nombre = "Album 200F 13x18 New Album",
                            precio = 17900m,
                            stock = 100
                        },
                        new
                        {
                            id = 3,
                            Rubro = 3,
                            eliminado = false,
                            nombre = "Reloj Digital Dakot 1845",
                            precio = 22300m,
                            stock = 100
                        });
                });

            modelBuilder.Entity("backNegocio.Models.Commons.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("user")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.DetalleImpresion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ImpresionId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("precioUnitario")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("id");

                    b.HasIndex("ImpresionId");

                    b.HasIndex("PedidoId");

                    b.ToTable("DetalleImpresion");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.DetallePedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("precioUnitario")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("FuePagado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ModoPagoId")
                        .HasColumnType("int");

                    b.Property<bool>("eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("estadoPedido")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaPedido")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ModoPagoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.DetalleImpresion", b =>
                {
                    b.HasOne("backNegocio.Models.Commons.Impresion", "impresion")
                        .WithMany()
                        .HasForeignKey("ImpresionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backNegocio.Models.Detalles.Pedido", "pedido")
                        .WithMany("DetallesImpresion")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("impresion");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.DetallePedido", b =>
                {
                    b.HasOne("backNegocio.Models.Detalles.Pedido", "pedido")
                        .WithMany("DetallesPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backNegocio.Models.Commons.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");

                    b.Navigation("producto");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.Pedido", b =>
                {
                    b.HasOne("backNegocio.Models.Commons.Cliente", "cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backNegocio.Models.Commons.ModoPago", "modoPago")
                        .WithMany()
                        .HasForeignKey("ModoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("modoPago");
                });

            modelBuilder.Entity("backNegocio.Models.Commons.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("backNegocio.Models.Detalles.Pedido", b =>
                {
                    b.Navigation("DetallesImpresion");

                    b.Navigation("DetallesPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
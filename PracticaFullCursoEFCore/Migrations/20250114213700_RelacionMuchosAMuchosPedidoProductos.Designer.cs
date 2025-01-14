﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaFullCursoEFCore.Data;

#nullable disable

namespace PracticaFullCursoEFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250114213700_RelacionMuchosAMuchosPedidoProductos")]
    partial class RelacionMuchosAMuchosPedidoProductos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Clientes", b =>
                {
                    b.Property<int>("ID_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Cliente"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ID_Membresia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID_Cliente");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.HasIndex("ID_Membresia")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Membresias", b =>
                {
                    b.Property<int>("ID_Membresia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Membresia"));

                    b.Property<decimal>("CostoMensual")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("TípoMembresia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID_Membresia");

                    b.ToTable("Membresias");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.PedidoProductos", b =>
                {
                    b.Property<int>("ID_Pedido")
                        .HasColumnType("int");

                    b.Property<int>("ID_Producto")
                        .HasColumnType("int");

                    b.HasKey("ID_Pedido", "ID_Producto");

                    b.HasIndex("ID_Producto");

                    b.ToTable("PedidoProductos");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Pedidos", b =>
                {
                    b.Property<int>("ID_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pedido"));

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Cliente")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Pedido");

                    b.HasIndex("ID_Cliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Productos", b =>
                {
                    b.Property<int>("ID_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Producto"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Producto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Clientes", b =>
                {
                    b.HasOne("PracticaFullCursoEFCore.Models.Membresias", "Membresias")
                        .WithOne("Clientes")
                        .HasForeignKey("PracticaFullCursoEFCore.Models.Clientes", "ID_Membresia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membresias");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.PedidoProductos", b =>
                {
                    b.HasOne("PracticaFullCursoEFCore.Models.Pedidos", "Pedidos")
                        .WithMany("ProductoPedidos")
                        .HasForeignKey("ID_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaFullCursoEFCore.Models.Productos", "Productos")
                        .WithMany("ProductoPedidos")
                        .HasForeignKey("ID_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedidos");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Pedidos", b =>
                {
                    b.HasOne("PracticaFullCursoEFCore.Models.Clientes", "Clientes")
                        .WithMany("Pedidos")
                        .HasForeignKey("ID_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Clientes", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Membresias", b =>
                {
                    b.Navigation("Clientes")
                        .IsRequired();
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Pedidos", b =>
                {
                    b.Navigation("ProductoPedidos");
                });

            modelBuilder.Entity("PracticaFullCursoEFCore.Models.Productos", b =>
                {
                    b.Navigation("ProductoPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDeOrdenes.DAL;

namespace RegistroDeOrdenes.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200620022657_CreateOrdenesDB")]
    partial class CreateOrdenesDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("RegistroDeOrdenes.Models.Ordenes", b =>
                {
                    b.Property<int>("ordenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("suplidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ordenId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("RegistroDeOrdenes.Models.OrdenesDetalle", b =>
                {
                    b.Property<int>("ordenDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("costo")
                        .HasColumnType("TEXT");

                    b.Property<int>("ordenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("productoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ordenDetalleId");

                    b.HasIndex("ordenId");

                    b.ToTable("OrdenesDetalle");
                });

            modelBuilder.Entity("RegistroDeOrdenes.Models.Productos", b =>
                {
                    b.Property<int>("productoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("inventario")
                        .HasColumnType("INTEGER");

                    b.HasKey("productoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            productoId = 1,
                            costo = 100m,
                            descripcion = "Salami",
                            inventario = 20
                        });
                });

            modelBuilder.Entity("RegistroDeOrdenes.Models.Suplidores", b =>
                {
                    b.Property<int>("suplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("suplidorId");

                    b.ToTable("Suplidores");

                    b.HasData(
                        new
                        {
                            suplidorId = 1,
                            nombre = "Induveca"
                        });
                });

            modelBuilder.Entity("RegistroDeOrdenes.Models.OrdenesDetalle", b =>
                {
                    b.HasOne("RegistroDeOrdenes.Models.Ordenes", null)
                        .WithMany("OrdenDetalles")
                        .HasForeignKey("ordenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

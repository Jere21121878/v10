﻿// <auto-generated />
using Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Back.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230916003845_234")]
    partial class _234
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Back.Models.Herramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Antesde")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedidaHerra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedidaUso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proteccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Riegos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Herramientas");
                });

            modelBuilder.Entity("Back.Models.Quimico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Almacenamiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnteDerramesyFugas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnteIncendio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aspecto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CAS")
                        .HasColumnType("int");

                    b.Property<int>("ClasedePeligroONU")
                        .HasColumnType("int");

                    b.Property<string>("Combustion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformacionFisicoQuimica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LimitesdeExposicionLaboral")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroOnu")
                        .HasColumnType("int");

                    b.Property<string>("PeligrosFisicos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeligrosQuimicos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrevencionIncendio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerosAuxilios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quimicos");
                });
#pragma warning restore 612, 618
        }
    }
}
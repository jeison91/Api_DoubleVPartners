﻿// <auto-generated />
using System;
using DoubleVPartners.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoubleVPartners.Infrastructure.Migrations
{
    [DbContext(typeof(PartnersDbContext))]
    partial class PartnersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoubleVPartners.Infrastructure.Entities.PersonaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(5);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(7);

                    b.Property<int>("IdTipoIdentificacion")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnOrder(3);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("IdTipoIdentificacion");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("DoubleVPartners.Infrastructure.Entities.TipoIdentificacionEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("TipoIdentificaciones");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            Descripcion = "Registro civil de nacimiento"
                        },
                        new
                        {
                            Id = 12,
                            Descripcion = "Tarjeta de identidad"
                        },
                        new
                        {
                            Id = 13,
                            Descripcion = "Cédula de ciudadanía"
                        },
                        new
                        {
                            Id = 21,
                            Descripcion = "Tarjeta de extranjería"
                        },
                        new
                        {
                            Id = 22,
                            Descripcion = "Cédula de extranjería"
                        },
                        new
                        {
                            Id = 31,
                            Descripcion = "NIT"
                        },
                        new
                        {
                            Id = 41,
                            Descripcion = "Pasaporte"
                        },
                        new
                        {
                            Id = 42,
                            Descripcion = "Tipo de documento extranjero"
                        });
                });

            modelBuilder.Entity("DoubleVPartners.Infrastructure.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnOrder(3);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DoubleVPartners.Infrastructure.Entities.PersonaEntity", b =>
                {
                    b.HasOne("DoubleVPartners.Infrastructure.Entities.TipoIdentificacionEntity", "tipoIdentificacion")
                        .WithMany()
                        .HasForeignKey("IdTipoIdentificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipoIdentificacion");
                });
#pragma warning restore 612, 618
        }
    }
}

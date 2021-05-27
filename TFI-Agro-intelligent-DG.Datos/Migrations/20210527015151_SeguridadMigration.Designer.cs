﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TFI_Agro_intelligent_DG.Contexts;

namespace TFIAgrointelligentDG.Datos.Migrations
{
    [DbContext(typeof(SeguridadContext))]
    [Migration("20210527015151_SeguridadMigration")]
    partial class SeguridadMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TFI_Agro_intelligent_DG.Seguridad.Modelo.Familia", b =>
                {
                    b.Property<int>("FamiliaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FamiliaPadreId")
                        .HasColumnType("int");

                    b.HasKey("FamiliaId");

                    b.HasIndex("FamiliaPadreId");

                    b.ToTable("Familias");

                    b.HasData(
                        new
                        {
                            FamiliaId = 1,
                            Descripcion = "Rol Administrador"
                        },
                        new
                        {
                            FamiliaId = 2,
                            Descripcion = "Rol Sistemas",
                            FamiliaPadreId = 1
                        });
                });

            modelBuilder.Entity("TFI_Agro_intelligent_DG.Seguridad.Modelo.FamiliaPatenteUsuario", b =>
                {
                    b.Property<int>("FamiliaPatenteUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<int>("PatenteId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FamiliaPatenteUsuarioId");

                    b.HasIndex("FamiliaId");

                    b.HasIndex("PatenteId");

                    b.ToTable("FamiliaPatentesUsuarios");

                    b.HasData(
                        new
                        {
                            FamiliaPatenteUsuarioId = 1,
                            FamiliaId = 1,
                            PatenteId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TFI_Agro_intelligent_DG.Seguridad.Modelo.Patente", b =>
                {
                    b.Property<int>("PatenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatenteId");

                    b.ToTable("Patentes");

                    b.HasData(
                        new
                        {
                            PatenteId = 1,
                            Descripcion = "Acceso Bitacora"
                        });
                });

            modelBuilder.Entity("TFI_Agro_intelligent_DG.Seguridad.Modelo.Familia", b =>
                {
                    b.HasOne("TFI_Agro_intelligent_DG.Seguridad.Modelo.Familia", "FamiliaPadre")
                        .WithMany()
                        .HasForeignKey("FamiliaPadreId");

                    b.Navigation("FamiliaPadre");
                });

            modelBuilder.Entity("TFI_Agro_intelligent_DG.Seguridad.Modelo.FamiliaPatenteUsuario", b =>
                {
                    b.HasOne("TFI_Agro_intelligent_DG.Seguridad.Modelo.Familia", "Familia")
                        .WithMany()
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFI_Agro_intelligent_DG.Seguridad.Modelo.Patente", "Patente")
                        .WithMany()
                        .HasForeignKey("PatenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");

                    b.Navigation("Patente");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(SitioSeriesConctext))]
    [Migration("20240317191435_ComentarioFecha")]
    partial class ComentarioFecha
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Categoria", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("categoria", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contenido");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("comentario", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pais");

                    b.HasKey("Id")
                        .HasName("PK_Pais");

                    b.HasIndex(new[] { "Nombre" }, "UQ_pais")
                        .IsUnique();

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Anio")
                        .HasColumnType("int")
                        .HasColumnName("anio");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("descripcion");

                    b.Property<int>("Duracion")
                        .HasColumnType("int")
                        .HasColumnName("duracion");

                    b.Property<string>("ImgPortada")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("img_portada");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("link");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("titulo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PaisId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("pelicula", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Anio")
                        .HasColumnType("int")
                        .HasColumnName("anio");

                    b.Property<int>("Capitulo")
                        .HasColumnType("int")
                        .HasColumnName("capitulo");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("descripcion");

                    b.Property<int>("Duracion")
                        .HasColumnType("int")
                        .HasColumnName("duracion");

                    b.Property<string>("ImgPortada")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("img_portada");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("link");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<double>("Puntuacion")
                        .HasColumnType("float")
                        .HasColumnName("puntuacion");

                    b.Property<int>("Temporada")
                        .HasColumnType("int")
                        .HasColumnName("temporada");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("titulo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Serie");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PaisId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex(new[] { "Titulo" }, "UQ_serie")
                        .IsUnique();

                    b.ToTable("serie", (string)null);
                });

            modelBuilder.Entity("Entities.Models.SeriesFavoritas", b =>
                {
                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("SerieId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("SeriesFavoritas");
                });

            modelBuilder.Entity("Entities.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("tipo");

                    b.HasKey("Id")
                        .HasName("PK_Tipo_Usuario");

                    b.ToTable("tipo_usuario", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("apellido");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("direccion");

                    b.Property<decimal>("Edad")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("edad");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date")
                        .HasColumnName("fecha_creacion");

                    b.Property<string>("ImgPerfil")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("imgPerfil");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nombre");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("password");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("usuario");

                    b.HasKey("Id")
                        .HasName("PK_Usuario");

                    b.HasIndex("PaisId");

                    b.HasIndex("TipoUsuarioId");

                    b.HasIndex(new[] { "User" }, "UK_Usuario")
                        .IsUnique();

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Comentario", b =>
                {
                    b.HasOne("Entities.Models.Serie", "Serie")
                        .WithMany("Comentarios")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Models.Pelicula", b =>
                {
                    b.HasOne("Entities.Models.Categoria", "Categoria")
                        .WithMany("Peliculas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Pais", "Pais")
                        .WithMany("Peliculas")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Usuario", "Usuario")
                        .WithMany("Peliculas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Pais");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Models.Serie", b =>
                {
                    b.HasOne("Entities.Models.Categoria", "Categoria")
                        .WithMany("Series")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Pais", "Pais")
                        .WithMany("Series")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.Usuario", "Usuario")
                        .WithMany("Series")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Pais");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Models.SeriesFavoritas", b =>
                {
                    b.HasOne("Entities.Models.Serie", "Serie")
                        .WithMany("SeriesFavoritas")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Usuario", "Usuario")
                        .WithMany("SeriesFavoritas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Models.Usuario", b =>
                {
                    b.HasOne("Entities.Models.Pais", "Pais")
                        .WithMany("Usuarios")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Entities.Models.Categoria", b =>
                {
                    b.Navigation("Peliculas");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("Entities.Models.Pais", b =>
                {
                    b.Navigation("Peliculas");

                    b.Navigation("Series");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entities.Models.Serie", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("SeriesFavoritas");
                });

            modelBuilder.Entity("Entities.Models.TipoUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entities.Models.Usuario", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Peliculas");

                    b.Navigation("Series");

                    b.Navigation("SeriesFavoritas");
                });
#pragma warning restore 612, 618
        }
    }
}
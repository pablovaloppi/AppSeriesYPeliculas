using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class SerieConfig : IEntityTypeConfiguration<Serie>
    {
        public void Configure( EntityTypeBuilder<Serie> builder ) {
            builder.HasKey( e => e.Id )
                    .HasName( "PK_Serie" );

            builder.ToTable( "serie" );

            builder.HasIndex( e => e.Titulo, "UQ_serie" )
                .IsUnique();

            builder.Property( e => e.Anio )
                .HasColumnType( "int" )
                .HasColumnName( "anio" );

            builder.Property( e => e.Capitulo )
                .HasColumnType( "int" )
                .HasColumnName( "capitulo" );

            builder.Property( e => e.Puntuacion )
                .HasColumnType( "float" )
                .HasColumnName( "puntuacion" );

            builder.Property( e => e.Descripcion )
                .HasMaxLength( 255 )
                .HasColumnName( "descripcion" );

            builder.Property( e => e.Duracion )
                .HasColumnType( "int" )
                .HasColumnName( "duracion" );

            builder.Property( e => e.ImgPortada )
                .HasMaxLength( 255 )
                .HasColumnName( "img_portada" );

            builder.Property( e => e.Link )
                .HasMaxLength( 255 )
                .HasColumnName( "link" );

            builder.Property( e => e.Temporada )
                .HasColumnType( "int" )
                .HasColumnName( "temporada" );

            builder.Property( e => e.Titulo )
                .HasMaxLength( 50 )
                .HasColumnName( "titulo" );


            builder.HasOne( d => d.Categoria )
                   .WithMany( p => p.Series )
                   .HasForeignKey( d => d.CategoriaId )
                   .OnDelete( DeleteBehavior.Restrict );

            builder.HasOne( d => d.Pais )
                   .WithMany( p => p.Series )
                   .HasForeignKey( d => d.PaisId )
                   .OnDelete( DeleteBehavior.Restrict );

            builder.HasOne( d => d.Usuario )
                   .WithMany( p => p.Series )
                   .HasForeignKey( d => d.UsuarioId )
                   .OnDelete( DeleteBehavior.Restrict );

        }
    }
}

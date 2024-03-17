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
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure( EntityTypeBuilder<Pelicula> builder ) {
            builder.HasKey( e => e.Id );

            builder.ToTable( "pelicula" );

            builder.Property( e => e.Anio )
                .HasColumnType( "int" )
                .HasColumnName( "anio" );

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

            builder.Property( e => e.Titulo )
                .HasMaxLength( 50 )
                .HasColumnName( "titulo" );
       
             builder.HasOne( d => d.Categoria )
                    .WithMany( p => p.Peliculas )
                    .HasForeignKey( d => d.CategoriaId )
                    .OnDelete( DeleteBehavior.Restrict );

            builder.HasOne( d => d.Pais )
                   .WithMany( p => p.Peliculas )
                   .HasForeignKey( d => d.PaisId )
                   .OnDelete( DeleteBehavior.Restrict );

            builder.HasOne( d => d.Usuario )
                   .WithMany( p => p.Peliculas )
                   .HasForeignKey( d => d.UsuarioId )
                   .OnDelete( DeleteBehavior.Restrict );

        }
    }   
}

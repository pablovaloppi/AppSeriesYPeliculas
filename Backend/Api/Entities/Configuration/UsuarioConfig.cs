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
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure( EntityTypeBuilder<Usuario> builder ) {
            builder.HasKey( e => e.Id )
            .HasName( "PK_Usuario" );

            builder.ToTable( "usuario" );

            builder.HasIndex( e => e.User, "UK_Usuario" )
                .IsUnique();

            builder.Property( e => e.Apellido )
                .HasMaxLength( 30 )
                .HasColumnName( "apellido" );

            builder.Property( e => e.Email )
                .HasMaxLength( 50 )
                .HasColumnName( "email" );

            builder.Property( e => e.Direccion )
                .HasMaxLength( 30 )
                .HasColumnName( "direccion" );

            builder.Property( e => e.Edad )
                .HasColumnType( "numeric(3, 0)" )
                .HasColumnName( "edad" );

            builder.Property( e => e.FechaCreacion )
                .HasColumnType( "date" )
                .HasColumnName( "fecha_creacion" );

            builder.Property( e => e.Nombre )
                .HasMaxLength( 30 )
                .HasColumnName( "nombre" );

            builder.Property( e => e.User )
                .HasMaxLength( 20 )
                .HasColumnName( "usuario" );

            builder.Property( e => e.Password )
                .HasMaxLength( 20 )
                .HasColumnName( "password" );
            builder.Property( e => e.ImgPerfil )
                .HasMaxLength( 255 )
                .HasColumnName( "imgPerfil" );

            builder.HasOne( d => d.Pais )
                .WithMany( p => p.Usuarios )
                .HasForeignKey( d => d.PaisId );

            builder.HasOne( d => d.TipoUsuario )
                .WithMany( p => p.Usuarios )
                .HasForeignKey( d => d.TipoUsuarioId );
        }
    }
}

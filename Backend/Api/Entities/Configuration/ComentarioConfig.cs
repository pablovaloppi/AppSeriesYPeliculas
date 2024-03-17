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
    public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure( EntityTypeBuilder<Comentario> builder ) {
            builder.HasKey( e => e.Id );

            builder.ToTable( "comentario" );

            builder.Property( e => e.Contenido )
                .HasColumnName( "contenido" );

            builder.Ignore( e => e.ImagenUser );
            builder.Ignore( e => e.NombreUsuario );

            builder.Property( e => e.Fecha ).HasColumnType( "date" );

            builder.HasOne( c => c.Serie )
                .WithMany( c => c.Comentarios )
                .HasForeignKey( f => f.SerieId );

            builder.HasOne( c => c.Usuario )
                .WithMany( c => c.Comentarios )
                .HasForeignKey( c => c.UsuarioId );

        }
    }
}

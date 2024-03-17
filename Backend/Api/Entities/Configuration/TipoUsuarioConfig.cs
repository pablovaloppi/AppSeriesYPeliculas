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
    public class TipoUsuarioConfig : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure( EntityTypeBuilder<TipoUsuario> builder ) {
            builder.HasKey( e => e.Id )
                   .HasName( "PK_Tipo_Usuario" );

            builder.ToTable( "tipo_usuario" );

            builder.Property( e => e.Tipo )
                .HasMaxLength( 20 )
                .HasColumnName( "tipo" );
        }
    }
}

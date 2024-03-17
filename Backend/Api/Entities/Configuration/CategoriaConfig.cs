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
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure( EntityTypeBuilder<Categoria> builder ) {

            builder.HasKey( e => e.Id );

            builder.ToTable( "categoria" );

            builder.Property( e => e.Nombre )
                .HasMaxLength( 20 )
                .IsUnicode( false )
                .HasColumnName( "nombre" );

        }
    }
}

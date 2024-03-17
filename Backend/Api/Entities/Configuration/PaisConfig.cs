using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class PaisConfig : IEntityTypeConfiguration<Pais>
    {
        public void Configure( EntityTypeBuilder<Pais> builder ) {
            builder.HasKey( e => e.Id )
                    .HasName( "PK_Pais" );

            builder.ToTable( "pais" );

            builder.HasIndex( e => e.Nombre, "UQ_pais" )
                    .IsUnique();

            builder.Property( e => e.Nombre )
                    .HasMaxLength( 50 )
                    .HasColumnName( "pais" );
        }
    }
}

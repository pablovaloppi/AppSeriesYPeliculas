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
    public class SerieFavoritasConfig : IEntityTypeConfiguration<SeriesFavoritas>
    {
        public void Configure( EntityTypeBuilder<SeriesFavoritas> builder ) {
            builder.HasKey( e => new { e.SerieId, e.UsuarioId } );

            builder.HasOne( e => e.Serie )
                .WithMany( e => e.SeriesFavoritas )
                .HasForeignKey(e => e.SerieId);

            builder.HasOne( e => e.Usuario )
                .WithMany( e => e.SeriesFavoritas )
                .HasForeignKey( e => e.UsuarioId );
        }
    }
}

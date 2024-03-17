using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Parameters
{
    public class SerieFavoritaParameters
    {
        public int UsuarioId { get; set; } = 0;
        public int SerieId { get; set; } = 0;

        public bool Count { get; set; } = false;
    }
}

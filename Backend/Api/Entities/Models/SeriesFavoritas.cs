using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SeriesFavoritas
    {
        public  int  Id { get; set; }
        public int SerieId { get; set; }
        public int UsuarioId { get; set; }

        public Serie Serie { get; set; }
        public Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comentario
    {
       public int Id { get; set; }
        public string Contenido { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string ImagenUser { get; set; }
        public string NombreUsuario { get; set; }
        public int UsuarioId { get; set; }
        public int SerieId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public Serie Serie { get; set; }

    }
}

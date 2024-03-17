using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string ImagenUser { get; set; }
        public int UsuarioId { get; set; }
    }
}

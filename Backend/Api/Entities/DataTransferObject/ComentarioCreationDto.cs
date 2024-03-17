using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class ComentarioCreationDto
    {
        public string Contenido { get; set; } = null!;
        public int UsuarioId { get; set; }
        public int SerieId { get; set; }
        public string ImagenUser { get; set; }
        public string NombreUsuario { get; set; }
    }
}

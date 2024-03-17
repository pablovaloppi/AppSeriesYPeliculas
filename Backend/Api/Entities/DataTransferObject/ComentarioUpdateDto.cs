using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class ComentarioUpdateDto
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = null!;
        public int UsuarioId { get; set; }
        public int SerieId { get; set; }
    }
}

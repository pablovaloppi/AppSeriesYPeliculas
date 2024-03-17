using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class UsuarioForLoginDto
    {
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public string ImgPerfil { get; set; } = null!;
        public int TipoUsuarioId { get; set; }
    }
}

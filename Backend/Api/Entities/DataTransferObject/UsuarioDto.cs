using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Edad { get; set; }
        public string Direccion { get; set; } = null!;
        public int PaisId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string ImgPerfil { get; set; } = null!;
    }
}

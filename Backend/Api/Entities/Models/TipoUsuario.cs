using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TipoUsuario
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

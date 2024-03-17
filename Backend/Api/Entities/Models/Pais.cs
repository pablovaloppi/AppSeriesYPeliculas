using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pelicula> Peliculas { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

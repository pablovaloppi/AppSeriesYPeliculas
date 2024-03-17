using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Categoria
    {
        public int? Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pelicula>? Peliculas { get; set; }
        public virtual ICollection<Serie>? Series { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string User{ get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;
        public decimal Edad { get; set; }
        public string Direccion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string ImgPerfil { get; set; } = null!;

        public int PaisId { get; set; }
        public int TipoUsuarioId { get; set; }

        public  Pais Pais { get; set; } = null!;
        public  TipoUsuario TipoUsuario { get; set; } = null!;

        public  ICollection<Pelicula> Peliculas { get; set; }
        public  ICollection<Serie> Series { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }

        public ICollection<SeriesFavoritas> SeriesFavoritas { get; set; }
    }
}

namespace Entities.Models
{
    public partial class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public float Puntuacion { get; set; }
        public string ImgPortada { get; set; } = null!;
        public int Anio { get; set; }
        public int Duracion { get; set; }
        public int Temporada { get; set; }
        public int Capitulo { get; set; }
        public string Link { get; set; } = null!;

        public int CategoriaId { get; set; }
        public int PaisId { get; set; }
        public int UsuarioId { get; set; }

        public  Categoria Categoria { get; set; } = null!;
        public Pais Pais { get; set; } = null!;
        public Usuario? Usuario { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<SeriesFavoritas> SeriesFavoritas { get; set; }
    }
}

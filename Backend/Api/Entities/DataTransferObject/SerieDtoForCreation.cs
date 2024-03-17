using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class SerieDtoForCreation
    {
        [Required( ErrorMessage = "Titulo is required" )]
        [StringLength( 255, ErrorMessage = "Titulo can't be longer than 200 characters" )]
        public string Titulo { get; set; } = null!;

        [Required( ErrorMessage = "Descripcion is required" )]
        [StringLength( 255, ErrorMessage = "Descripcion can't be longer than 255 characters" )]
        public string Descripcion { get; set; } = null!;

        [Required( ErrorMessage = "ImgPortada is required" )]
        public string ImgPortada { get; set; } = null!;

        [Required( ErrorMessage = "Anio is required" )]
        public int Anio { get; set; }

        [Required( ErrorMessage = "CategoriaId is required" )]
        public int CategoriaId { get; set; }

        [Required( ErrorMessage = "PaisId is required" )]
        public int PaisId { get; set; }

        [Required( ErrorMessage = "Duracion is required" )]
        public int Duracion { get; set; }

        [Required( ErrorMessage = "Temporada is required" )]
        public int Temporada { get; set; }

        [Required( ErrorMessage = "Capitulo is required" )]
        public int Capitulo { get; set; }

        [Required( ErrorMessage = "Link is required" )]
        public string Link { get; set; } = null!;

        [Required( ErrorMessage = "UsuarioId is required" )]
        public int? UsuarioId { get; set; }
    }
}


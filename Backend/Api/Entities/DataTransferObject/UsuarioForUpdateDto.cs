using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class UsuarioForUpdateDto
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Name is required" )]
        [StringLength( 60, ErrorMessage = "Name can't be longer than 60 characters" )]
        public string Nombre { get; set; } = null!;

        [Required( ErrorMessage = "Apellido is required" )]
        [StringLength( 60, ErrorMessage = "Apellido can't be longer than 60 characters" )]
        public string Apellido { get; set; } = null!;

        [Required( ErrorMessage = "Age is required" )]
        public decimal Edad { get; set; }

        [Required( ErrorMessage = "Direccion is required" )]
        [StringLength( 60, ErrorMessage = "Direccion can't be longer than 255 characters" )]
        public string Direccion { get; set; } = null!;
        
        
        public string ImgPerfil { get; set; } = null!;
    }
}

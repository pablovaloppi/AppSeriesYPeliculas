using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class UsuarioForCreationDto
    {
        [Required(ErrorMessage="User is required")]
        [StringLength(60, ErrorMessage ="User can't be longer than 60 characters")]
        public string User { get; set; } = null!;

        [Required( ErrorMessage = "Password is required" )]
        [StringLength( 20, ErrorMessage = "User can't be longer than 20 characters" )]
        public string Password { get; set; } = null!;

        [Required( ErrorMessage = "Name is required" )]
        [StringLength( 60, ErrorMessage = "Name can't be longer than 60 characters" )]
        public string Nombre { get; set; } = null!;

        [Required( ErrorMessage = "Apellido is required" )]
        [StringLength( 60, ErrorMessage = "Apellido can't be longer than 60 characters" )]
        public string Apellido { get; set; } = null!;

        [Required( ErrorMessage = "Email is required" )]
        public string Email { get; set; }

        [Required( ErrorMessage = "Age is required" )]
        public decimal Edad { get; set; }


        [Required( ErrorMessage = "Country is required" )]
        public int PaisId { get; set; }

        [Required( ErrorMessage = "Direccion is required" )]
        [StringLength( 60, ErrorMessage = "Direccion can't be longer than 255 characters" )]
        public string Direccion { get; set; } = null!;

        public string ImgPerfil { get; set; } = null!;
    }
}

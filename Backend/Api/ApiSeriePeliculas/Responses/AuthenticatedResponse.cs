using Entities.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AuthenticatedResponse {
        public UsuarioForLoginDto? Usuario { get; set; }
        public string? Token { get; set; }
    }
}

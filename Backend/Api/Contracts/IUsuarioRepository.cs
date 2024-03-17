using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{                                       // Si heredo esto puedo acceder desde el controlador todos los metodos bases
    public interface IUsuarioRepository// : IRepositoryBase<Usuario>
    {
        PagedList<Usuario> GetAll(UserParameters parameters);
        Usuario GetUsuario(int id);

        Usuario GetUsuarioByUsername(string userName);
        string GetRoleUser( Usuario usuario );
        void CreateUsuario(Usuario usuario);

        void UpdateUsuario( Usuario usuario );
        
        void DeleteUsuario( Usuario usuario);
    }
}

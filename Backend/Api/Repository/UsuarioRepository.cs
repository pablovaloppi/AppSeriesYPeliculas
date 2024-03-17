
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Entities.Parameters;

namespace Repository
{
    internal class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }

        public void CreateUsuario( Usuario usuario ) {
            Create( usuario );
        }

        public void DeleteUsuario( Usuario usuario ) {
            Delete( usuario );
        }

        public PagedList<Usuario> GetAll(UserParameters parameters) {
            return PagedList<Usuario>.ToPagedList( FindAll(), parameters.PageNumber, parameters.PageSize );
        }

        public Usuario GetUsuario( int id ) {
            return FindByCondition( usuario => usuario.Id == id ).FirstOrDefault();
        }

        public Usuario GetUsuarioByUsername( string userName ) => SitioSeriesConctext.Usuarios.Where( user => user.User == userName ).FirstOrDefault();
    
        public string GetRoleUser(Usuario usuario)  => SitioSeriesConctext.TipoUsuarios.Where( type => type.Id == usuario.Id ).FirstOrDefault().Tipo;
            

        public void UpdateUsuario( Usuario usuario ) {
            Update( usuario );
        }
    }
}

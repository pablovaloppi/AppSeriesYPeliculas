using Contracts;
using Entities.Models;
using Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ComentarioRepository : RepositoryBase<Comentario>, IComentarioRepository
    {
        public ComentarioRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }

        public void CreateComentario( Comentario comentario ) {
            Create( comentario );
        }

        public void DeleteComentario( Comentario comentario ) {
            Delete( comentario );
        }
        public void UpdateComentario( Comentario comentario ) {
            Update( comentario );
        }
        public Comentario GetById( int id ) {

            var comentarios = from comentario in SitioSeriesConctext.Comentarios
                              join usuario in SitioSeriesConctext.Usuarios
                              on comentario.UsuarioId equals usuario.Id
                              where comentario.Id == id
                              select new Comentario() {
                                  Id = comentario.Id,
                                  Contenido = comentario.Contenido, Fecha = comentario.Fecha, ImagenUser = usuario.ImgPerfil,
                                  UsuarioId = comentario.UsuarioId, SerieId = comentario.SerieId, Usuario = comentario.Usuario,
                                  Serie = comentario.Serie, NombreUsuario = usuario.User
                              };
            return comentarios.FirstOrDefault();
        }

        

        public PagedList<Comentario> GetAll( ComentarioParameters parameters ) {
            if( parameters.SerieId != 0 ) {
                var comentarios = from comentario in SitioSeriesConctext.Comentarios
                                  join usuario in SitioSeriesConctext.Usuarios
                                  on comentario.UsuarioId equals usuario.Id
                                  where comentario.SerieId == parameters.SerieId
                                  select new Comentario() {
                                      Id = comentario.Id,
                                      Contenido = comentario.Contenido, Fecha = comentario.Fecha, ImagenUser = usuario.ImgPerfil,
                                      UsuarioId = comentario.UsuarioId, SerieId = comentario.SerieId, Usuario = comentario.Usuario,
                                      Serie = comentario.Serie, NombreUsuario = usuario.User
                             };
                return PagedList<Comentario>.ToPagedList( comentarios, parameters.PageNumber, parameters.PageSize );
            }

            var result = from comentario in SitioSeriesConctext.Comentarios
                         join usuario in SitioSeriesConctext.Usuarios
                         on comentario.UsuarioId equals usuario.Id
                         select new Comentario() {
                             Id = comentario.Id,
                             Contenido = comentario.Contenido, Fecha = comentario.Fecha, ImagenUser = usuario.ImgPerfil,
                             UsuarioId = comentario.UsuarioId, SerieId = comentario.SerieId, Usuario = comentario.Usuario,
                             Serie = comentario.Serie, NombreUsuario = usuario.User
                         };
            return PagedList<Comentario>.ToPagedList( result, parameters.PageNumber, parameters.PageSize );
        }

 
    }
}

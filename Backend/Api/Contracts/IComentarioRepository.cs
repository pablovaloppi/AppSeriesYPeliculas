using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IComentarioRepository
    {
        PagedList<Comentario> GetAll( ComentarioParameters parameters );
        Comentario GetById( int id );

        void CreateComentario( Comentario comentario );

        void DeleteComentario(Comentario comentario );

        void UpdateComentario( Comentario comentario );

    }
}

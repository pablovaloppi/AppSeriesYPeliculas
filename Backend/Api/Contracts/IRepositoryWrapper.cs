using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public  interface IRepositoryWrapper
    {
        IUsuarioRepository Usuario { get; }
        ISerieRepository Serie { get; }
        IPeliculaRepository Movie { get; }
        ICategoryRepository Category { get; }

        IComentarioRepository Comentario { get; }
        IPaisRepository Pais { get; }

        ISerieFavoritaRepository SerieFavorita { get; }
        void Save();
    }
}

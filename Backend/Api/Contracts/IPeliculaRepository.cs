using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPeliculaRepository //: IRepositoryBase<Pelicula>
    {
        IEnumerable<Pelicula> GetAll();
        Pelicula GetMovieById( int id );
        void CreateMovie( Pelicula movie );
        void UpdateMovie( Pelicula movie );
        void DeleteMovie( Pelicula movie );
    }
}

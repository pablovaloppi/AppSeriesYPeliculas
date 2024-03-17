using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PeliculaRepository : RepositoryBase<Pelicula>, IPeliculaRepository
    {
        public PeliculaRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }

        public void CreateMovie( Pelicula movie ) {
            Create( movie );
        }

        public void DeleteMovie( Pelicula movie ) {
            Delete( movie );
        }

        public IEnumerable<Pelicula> GetAll() {
            return FindAll().OrderBy( p => p.Titulo );
        }

        public Pelicula GetMovieById( int id ) {
            return FindByCondition( a => a.Id == id ).FirstOrDefault<Pelicula>();
        }

        public void UpdateMovie( Pelicula movie ) {
            Update( movie );
        }
    }
}

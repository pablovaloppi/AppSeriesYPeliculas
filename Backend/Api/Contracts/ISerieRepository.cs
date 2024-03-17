using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISerieRepository
    {
        PagedList<Serie> GetAll( SerieParameters parameters );
        Serie GetSerieById( int id );
        public IEnumerable<Serie> GetAll();
        public IEnumerable<Serie> SeriesFavoritas(int usuarioId);
        Serie GetSerieByTitle( string title );
        void CreateSerie( Serie serie );
        void UpdateSerie( Serie serie );
        void DeleteSerie( Serie serie );

    }
}

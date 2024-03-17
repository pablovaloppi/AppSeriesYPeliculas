using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISerieFavoritaRepository //: IRepositoryBase<SeriesFavoritas>
    {
        IEnumerable<SeriesFavoritas> GetAllbyUsuario(int usuarioId);
        IEnumerable<SeriesFavoritas> GetAllbySerie(int serieId);
        void CreateFavorito(SeriesFavoritas seriesFavoritas);
        void DeleteFavorito( SeriesFavoritas seriFavoritas );
        SeriesFavoritas GetSeriesFavoritas( int usuarioId, int serieId );
    }
}

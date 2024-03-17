using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SerieFavoritaRepository : RepositoryBase<SeriesFavoritas>, ISerieFavoritaRepository
    {
        public SerieFavoritaRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }

        public void CreateFavorito( SeriesFavoritas seriesFavoritas ) {
            Create( seriesFavoritas );
        }

        public void DeleteFavorito( SeriesFavoritas seriFavoritas ) {
            Delete(seriFavoritas);
        }

        public IEnumerable<SeriesFavoritas> GetAllbySerie( int serieId ) {
            return FindByCondition( s => s.SerieId == serieId ).ToList();
        }

        public IEnumerable<SeriesFavoritas> GetAllbyUsuario( int usuarioId ) {
            return FindByCondition( s => s.UsuarioId == usuarioId ).ToList();
        }

        public SeriesFavoritas GetSeriesFavoritas( int usuarioId, int serieId ) {
            return FindByCondition( s => s.UsuarioId == usuarioId & s.SerieId == serieId ).FirstOrDefault();
        }
    }
}

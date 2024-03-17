using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiSeriePeliculas.Core.Services
{
    public class SerieFavoritaService
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
        public SerieFavoritaService(IRepositoryWrapper repository, ILoggerManager logger) {
            _repository = repository;
            _logger = logger;
        }

        public bool estaEnFavorita(SerieFavoritaDto serieFavorita ) {
            return _repository.SerieFavorita.GetSeriesFavoritas(serieFavorita.UsuarioId, serieFavorita.SerieId) != null;
        }

        public IEnumerable<Serie> SeriesFavoritasPorUsuario(SerieFavoritaParameters parameters) {
            if(parameters.SerieId == 0 ) {
                
                return _repository.Serie.SeriesFavoritas(parameters.UsuarioId);
            }
            _logger.LogError( "SerieId es disntino a cero" );
            return null;
        }
    }
}

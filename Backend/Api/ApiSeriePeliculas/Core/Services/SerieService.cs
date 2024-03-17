using Contracts;
using Entities.DataTransferObject;
using Entities.Models;

namespace ApiSeriePeliculas.Core.Services
{
    public class SerieService
    {
        IRepositoryWrapper _repository;


        public SerieService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }


        public bool isInDatabase( Serie serie ) {

            if( _repository.Serie.GetSerieByTitle( serie.Titulo ) != null ) {
                return true;
            }

            return false;
        }

        public bool isInDatabase( SerieDtoForCreation serie ) {

            if( _repository.Serie.GetSerieByTitle( serie.Titulo ) != null ) {
                return true;
            }

            return false;
        }
    }
}

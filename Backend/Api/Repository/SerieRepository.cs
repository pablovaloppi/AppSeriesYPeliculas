
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Entities.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        public SerieRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }

        public void CreateSerie( Serie serie ) {
            Create( serie );
        }

        public void DeleteSerie( Serie serie ) {
            Delete( serie );
        }

        public PagedList<Serie> GetAll(SerieParameters parameters) {
            if(parameters.CategoriaId != 0 ) {
                var series = FindByCondition( series => series.CategoriaId == parameters.CategoriaId );
                return PagedList<Serie>.ToPagedList( series, parameters.PageNumber, parameters.PageSize );
            }    

            return PagedList<Serie>.ToPagedList( FindAll(), parameters.PageNumber,parameters.PageSize );
        }
        
        public IEnumerable<Serie> GetAll() {
            return FindAll().ToList();
        }
        
        public Serie GetSerieById( int id ) {
            return FindByCondition( a => a.Id == id ).FirstOrDefault();
        }

        public Serie GetSerieByTitle( string title ) {
            return FindByCondition( a => String.Equals( a.Titulo.ToLower(), title.ToLower())).FirstOrDefault();
        }

        public IEnumerable<Serie> SeriesFavoritas( int usuarioId ) {
         //   var result = SitioSeriesConctext.SeriesFavoritas
          //      .Join( SitioSeriesConctext.Series, sf => sf.SerieId, s => s.Id, ( s, sf ) => s ).Where(s => s.UsuarioId == usuarioId);
            var result = from series in SitioSeriesConctext.Series
                        join serieFavoritas in SitioSeriesConctext.SeriesFavoritas
                        on series.Id equals serieFavoritas.SerieId
                        where serieFavoritas.UsuarioId == usuarioId
                        select series;
            return result;
        }

        public void UpdateSerie( Serie serie ) {
            Update( serie );
        }
    }
}

using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SitioSeriesConctext _sitioSeriesConctext;
        private IUsuarioRepository _usuario;
        private ISerieRepository _serie;
        private IPeliculaRepository _movie;
        private ICategoryRepository _category;
        private IPaisRepository _pais;
        private IComentarioRepository _comentario;

        public ISerieFavoritaRepository _seriefavorita;
        public IUsuarioRepository Usuario { get {
                if( _usuario == null ) {
                    _usuario = new UsuarioRepository( _sitioSeriesConctext );
                }

                return _usuario;
            }
        }
        public ISerieRepository Serie {
            get {
                if( _serie == null ) {
                    _serie = new SerieRepository( _sitioSeriesConctext );
                }

                return _serie;
            }
        }

        public IPeliculaRepository Movie {
            get {
                if( _movie is null ) {
                    _movie = new PeliculaRepository( _sitioSeriesConctext );
                }
                return _movie;
            }
        }

        public ICategoryRepository Category {
            get {
                if( _category is null ) {
                    _category = new CategoryRepository( _sitioSeriesConctext );
                }
                return _category;
            }
        }

        public IComentarioRepository Comentario {
            get {
                if(_comentario is null ) {
                    _comentario = new ComentarioRepository( _sitioSeriesConctext );
                }
                return _comentario;
            }
        }

        public IPaisRepository Pais {
            get {
                if( _pais is null ) {
                    _pais = new PaisRepository( _sitioSeriesConctext );
                }
                return _pais;
            }
        }

        public ISerieFavoritaRepository SerieFavorita {
            get {
                if( _seriefavorita is null ) {
                    _seriefavorita = new SerieFavoritaRepository( _sitioSeriesConctext );
                }
                return _seriefavorita;
            }
        }

        public RepositoryWrapper(SitioSeriesConctext sitioSeriesConctext)
        {
            _sitioSeriesConctext = sitioSeriesConctext;
        }
        public void Save() {
            _sitioSeriesConctext.SaveChanges();
        }
    }
}

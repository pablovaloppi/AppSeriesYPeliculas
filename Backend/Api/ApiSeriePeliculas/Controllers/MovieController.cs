using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/movie" )]
    [ApiController]
    public class MovieController : ControllerBase {
        IRepositoryWrapper _repository;
        ILoggerManager _logger;
        IMapper _mapper;
        public MovieController( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper ) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMovie() {
            try {
                var movies = _repository.Movie.GetAll();

                _logger.LogInfo( "Se han obtenido todos las peliculas." );

                var moviesResult = _mapper.Map<IEnumerable<PeliculaDto>>( movies );
                return Ok( moviesResult );
            }
            catch( Exception ex ) {
                return MessageError( "GetAllMovie", ex );
            }
        }

        [HttpGet( "{id}" )]
        public IActionResult GetMovieById( int id ) {

            try {
                var movie = _repository.Movie.GetMovieById( id );

                if( movie is null ) {
                    _logger.LogError( $"La pelicula con el id: {id} no se encuentra en la base de datos" );
                    return NotFound( $"La pelicula no se encuentra en la base de datos." );
                }

                _logger.LogInfo( $"La pelicula con el id: {id} se ha obtenido con exito." );
                var movieResult = _mapper.Map<PeliculaDto>( movie );

                return Ok( movieResult );
            }
            catch( Exception ex ) {

                return MessageError( "GetMovieById", ex );
            }
        }

        [HttpPost]
        public IActionResult CreateMovie( PeliculaDto movieCreate ) {
            try {
                if( movieCreate is null ) {
                    _logger.LogError( "El objeto Pelicula enviado es nulo" );
                    return BadRequest( "El objeto Pelicula enviado es nulo" );
                }

                if( !ModelState.IsValid ) {
                    _logger.LogError( "El objeto Pelicula enviado no es valido" );
                    return BadRequest( "El objeto Pelicula enviado no es valido" );
                }

                var movie = _mapper.Map<Pelicula>( movieCreate );
                _logger.LogInfo( $"La pelicula {movie.Titulo} se ha creado con exito." );
                _repository.Movie.CreateMovie( movie );
                _repository.Save();

                var movieResutl = _mapper.Map<PeliculaDto>( movie );
                return Created( "Se ha creado con exito.", movieResutl );
            }
            catch( Exception ex ) {
                return MessageError( "CreateMovie", ex );
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie( int id, PeliculaForUpdate movieUpdate ) {
            try {
                if( movieUpdate is null ) {
                    _logger.LogError( "El objeto Pelicula enviado es nulo" );
                    return BadRequest( "El objeto Pelicula enviado es nulo" );
                }

                if( !ModelState.IsValid ) {
                    _logger.LogError( "El objeto Pelicula enviado no es valido" );
                    return BadRequest( "El objeto Pelicula enviado no es valido" );
                }

                var movie = _repository.Movie.GetMovieById( id );

                if( movie is null ) {
                    _logger.LogError( $"La pelicula con el id: {id} no se encuentra en la base de datos" );
                    return NotFound( $"La pelicula no se encuentra en la base de datos." );
                }

                var movieResult = _mapper.Map<Pelicula>( movieUpdate );
                _logger.LogInfo( $"La pelicula {movieResult.Titulo} se ha actualizado con exito." );
                _repository.Movie.UpdateMovie( movieResult );
                _repository.Save();

                return NoContent();
            }
            catch( Exception ex ) {
                return MessageError( "UpdateMovie", ex );
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id ) {
            try {
                var movie = _repository.Movie.GetMovieById( id );

                if( movie is null ) {
                    _logger.LogError( $"La pelicula con el id: {id} no se encuentra en la base de datos" );
                    return NotFound( $"La pelicula no se encuentra en la base de datos." );
                }

                _logger.LogInfo( $"La pelicula {movie.Titulo} se ha eliminado con exito." );
                _repository.Movie.DeleteMovie( movie );
                _repository.Save();

                return NoContent();
                
            }
            catch( Exception ex ) {
                return MessageError( "CreateMovie", ex );
            }
        }
        private IActionResult MessageError( string functionName, Exception ex ) {
            _logger.LogError( $"Algo ocurrion en la funcion {functionName}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

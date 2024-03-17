using ApiSeriePeliculas.Core.Services;
using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class SerieFavoritaController : ControllerBase {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly SerieFavoritaService _serieFavoritaService;

        public SerieFavoritaController( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper, SerieFavoritaService serieFavoritaService ) {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            this._serieFavoritaService = serieFavoritaService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Agregar( SerieFavoritaDto serieFavorita ) {
            try {
                if( _serieFavoritaService.estaEnFavorita( serieFavorita ) ) {
                    _logger.LogError( "La serieFavorita ya esta en favoritos" );
                    return BadRequest( "La serieFavorita ya esta en favoritos" );
                }
                if( serieFavorita is null ) {
                    _logger.LogError( "La serieFavorita esta vacio" );
                    return BadRequest( "La serieFavorita esta vacio" );
                }

                var result = _mapper.Map<SeriesFavoritas>( serieFavorita );
                _repository.SerieFavorita.CreateFavorito( result );
                
                _repository.Save();
                _logger.LogInfo( "Se agrego correctamete la serie a favoritos" );

                return NoContent();
            }
            catch( Exception ex ) {

                return ErrorMessage( "Agregar", ex );
            }
        }

        [HttpDelete( "{usuarioId}/{serieId}" )]
        [Authorize]
        public IActionResult Borrar( int usuarioId, int serieId ) {
            try {
                var serieFavorita = _repository.SerieFavorita.GetSeriesFavoritas( usuarioId, serieId );

                if( serieFavorita is null ) {
                    _logger.LogError( " No se ha encontrado la serie favorita." );
                    return BadRequest( " No se ha encontrado la serie favorita." );
                }

                _repository.SerieFavorita.DeleteFavorito( serieFavorita );
                _repository.Save();

                _logger.LogInfo( "La serie favorita se ha borrado correctamente." );

                return NoContent();
            }
            catch( Exception ex ) {

                return ErrorMessage( "Borrar", ex );
            }
        }

        [HttpGet( "{usuarioId}/{serieId}" )]
        public IActionResult GetFavorito( int usuarioId, int serieId ) {
            try {
                var serieFavorita = _repository.SerieFavorita.GetSeriesFavoritas( usuarioId, serieId );

                if( serieFavorita is null ) {
                    _logger.LogError( " No se ha encontrado la serie favorita." );
                    return BadRequest( " No se ha encontrado la serie favorita." );
                }

                var result = _mapper.Map<SerieFavoritaDto>( serieFavorita );
                _logger.LogInfo( "La serie favorita se ha obtenido correctamente." );

                return Ok( result );
            }
            catch( Exception ex ) {

                return ErrorMessage( "Borrar", ex );
            }
        }

        [HttpGet]
        public IActionResult SeriesFavoritas([FromQuery] SerieFavoritaParameters paramaters ) {
            try {
                var series = _serieFavoritaService.SeriesFavoritasPorUsuario( paramaters );

                if(series is null ) {
                    _logger.LogError( "El usuario no tiene series favoritas." );
                    return BadRequest( "El usuario no tiene series favoritas." );
                }

                var result = _mapper.Map<IEnumerable<SerieDto>>(series );
                _logger.LogInfo( "Se han obtenido todas las series favoritas" );

                if( paramaters.Count )
                    return Ok( result.Count() );

                return Ok( result );
            }
            catch( Exception ex ) {

                return ErrorMessage( "SeriesFavortias", ex );
            }
        }
        private IActionResult ErrorMessage( string nameFunction, Exception ex ) {
            _logger.LogError( $"Ocurrio un error dentro de la funcion {nameFunction}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

using ApiSeriePeliculas.Core.Services;
using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiSeriePeliculas.Controllers
{

    [Route( "api/serie" )]
    [ApiController]
    public class SerieController : ControllerBase
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        SerieService _serieService;
        public SerieController( ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _serieService = new SerieService( _repository );
        }
        [HttpGet]
        public IActionResult GetSeries([FromQuery] SerieParameters parameters) {
            try {
                var series = _repository.Serie.GetAll(parameters);

                var metadata = new {
                    series.TotalCount,
                    series.PageSize,
                    series.CurrentPage,
                    series.TotalPages,
                    series.HasNext,
                    series.HasPrevious
                };

                Response.Headers.Add( "X-Pagination", JsonConvert.SerializeObject( metadata ) );
                _logger.LogInfo( $"Se han obtenido {series.TotalCount} series correctamente." );

                var serieResult = _mapper.Map<IEnumerable<SerieDto>>( series );
                foreach( var item in serieResult ) {
                   item.NombreCategoria = _repository.Category.GetCategoryById( item.CategoriaId ).Nombre;
                }
                return Ok(serieResult);          
            }
            catch( Exception ex ) {
                return ErrorMessage( "GetAllSerie", ex );
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetSerieById(int id ) {
            try {
                var serie = _repository.Serie.GetSerieById( id );

                if( serie is null ) {
                    _logger.LogError( $"La serie con el id:{id} no se encuentra en la base de datos" );
                    return NotFound();
                }

                _logger.LogInfo( $"Se retorna la serie con el id:{id}." );
                var serieResult = _mapper.Map<SerieDto>( serie );
                serieResult.NombreCategoria = _repository.Category.GetCategoryById( serieResult.CategoriaId ).Nombre;

                return Ok( serieResult );
            }
            catch( Exception ex ) {
                return ErrorMessage( "GetSerieById", ex );
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateSerie(SerieDtoForCreation serieDto ) {
            try {
                if( serieDto is null ) {
                    _logger.LogError( "El objeto Serie enviado es nulo." );
                    return BadRequest("Objeto Serie es nulo.");
                }
                if( !ModelState.IsValid ) {
                    _logger.LogError( "El objeto Serie enviado es invalido." );
                    return BadRequest( "Objeto Serie es invalido." );
                }

                if(_serieService.isInDatabase( serieDto ) ) {
                    _logger.LogError( "La serie ya se encuentra en la base de datos." );
                    return BadRequest( "La serie ya se encuentra en la base de datos." );
                }
                var serie = _mapper.Map<Serie>( serieDto );
                _repository.Serie.CreateSerie( serie );
                _repository.Save();
                _logger.LogInfo( $"El Serie: {serie.Titulo} se ha creado con exito." );

                var serieCreated = _mapper.Map<SerieDto>( serie );
                return Created( "Serie creada con exito.", serieCreated );

            }
            catch( Exception ex ) {
                return ErrorMessage( "CreateSerie", ex );
            }
        }

        [HttpPut( "{id}" )]
        [Authorize]
        public IActionResult UpdateSerie(int id, SerieForUpdate serieForUpdate) {
            try {
                if( serieForUpdate is null ) {
                    _logger.LogError( "El objeto Serie enviado es nulo." );
                    return BadRequest( "Objeto Serie es nulo." );
                }
                if( !ModelState.IsValid ) {
                    _logger.LogError( "El objeto Serie enviado es invalido." );
                    return BadRequest( "Objeto Serie es invalido." );
                }

                var serie = _repository.Serie.GetSerieById(id);
                if(serie is null ) {
                    _logger.LogError( $"El objeto Serie con el id: {id} no se encuentra en la base de datos." );
                    return NotFound( "Objeto Serie no se encuentra en la base de datos." );
                }

                var serieEntity = _mapper.Map<Serie>( serieForUpdate );
                serieEntity.Id = id;  

                _repository.Serie.UpdateSerie( serieEntity );
                _repository.Save();

                _logger.LogInfo( $"La serie {serie.Titulo} se a actualizado correctamente" );

                return NoContent();

                
            }
            catch( Exception ex ) {

                return ErrorMessage( "UpdateSerie", ex );
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteSerie(int id) {
            try {
                var serie = _repository.Serie.GetSerieById( id );

                if( serie is null ) {
                    _logger.LogError( $"El objeto Serie con el id: {id} no se encuentra en la base de datos." );
                    return NotFound( "Objeto Serie no se encuentra en la base de datos." );
                }

                _logger.LogInfo( $"La serie {serie.Titulo} se a eliminado correctamente" );
                _repository.Serie.DeleteSerie( serie );
                _repository.Save();

                return NoContent(); 
            }
            catch( Exception ex) {
                return ErrorMessage( "DeleteSerie", ex );
            }
        }
        
        private IActionResult ErrorMessage(string nameFunction, Exception ex) {
            _logger.LogError( $"Ocurrio un error dentro de la funcion {nameFunction}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

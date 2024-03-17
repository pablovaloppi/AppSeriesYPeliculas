using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ComentarioController : ControllerBase {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ComentarioController( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper ) {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComentarios( [FromQuery] ComentarioParameters parameters ) {
            try {
                var comentarios = _repository.Comentario.GetAll( parameters );

                var metadata = new {
                    comentarios.TotalCount,
                    comentarios.PageSize,
                    comentarios.CurrentPage,
                    comentarios.TotalPages,
                    comentarios.HasNext,
                    comentarios.HasPrevious
                };

                Response.Headers.Add( "X-Pagination", JsonConvert.SerializeObject( metadata ) );
                _logger.LogInfo( $"Se han obtenido {comentarios.TotalCount} comentarios correctamente." );


                _logger.LogInfo( $"Se han obtenido todos los comentarios correctamente." );

                var result = _mapper.Map<IEnumerable<ComentarioDto>>( comentarios );
                

                return Ok( result );
            }
            catch( Exception ex ) {

                return ErrorMessage( "GetComentarios", ex );
            }
        }

        [HttpGet( "{id}" )]
        public IActionResult GetById( int id ) {
            try {
                var comentario = _repository.Comentario.GetById( id );

                if( comentario is null ) {
                    _logger.LogError( "El comentario no se encuentra en la base de datos" );
                    return BadRequest( "El comentario no se encuentra en la base de datos" );
                }

                var result = _mapper.Map<ComentarioDto>( comentario );
                _logger.LogInfo( $"Se ha obtenido correctamente el comentario nro: {id}." );

                return Ok( result );
            }
            catch( Exception ex ) {

                return ErrorMessage( "GetById", ex );
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateComentario( ComentarioCreationDto comentario ) {
            try {
                if( comentario is null ) {
                    _logger.LogError( "El comentario esta vacio." );
                    return BadRequest( "El comentario esta vacio." );
                }

                var result = _mapper.Map<Comentario>( comentario );
                result.Fecha = DateTime.Now;

                _repository.Comentario.CreateComentario( result );
                _repository.Save();

                _logger.LogInfo( "El comentario se ha creado exitosamente." );

                return CreatedAtAction( nameof( GetById ), new { result.Id }, result );
            }
            catch( Exception ex ) {

                return ErrorMessage( "CreateComentario", ex );
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteComentario(int id ) {
            try {
                var comentario = _repository.Comentario.GetById( id );
                if( comentario is null ) {
                    _logger.LogError( "El comentario no se encuentra en la base de datos" );
                    return BadRequest( "El comentario no se encuentra en la base de datos" );
                }

                _repository.Comentario.DeleteComentario( comentario );
                _repository.Save();

                _logger.LogInfo( "El comentario nro: {id}, se ha borrado correctamente." );

                return NoContent();

            }
            catch( Exception ex ) {
                return ErrorMessage( "DeleteComentario", ex );
            }
        }

        [HttpPut( "{id}" )]
        [Authorize]
        public IActionResult UpdateComentario( int id, ComentarioUpdateDto comentarioNuevo ) {
            try {
                var comentario = _repository.Comentario.GetById( id );
                if( comentario is null ) {
                    _logger.LogError( "El comentario no se encuentra en la base de datos" );
                    return BadRequest( "El comentario no se encuentra en la base de datos" );
                }

                var result = _mapper.Map<Comentario>( comentarioNuevo );
                _repository.Comentario.UpdateComentario( result );
                _repository.Save();

                _logger.LogInfo( "El comentario nro: {id}, se ha actualizado correctamente." );

                return Ok();
            }
            catch( Exception ex ) {
                return ErrorMessage( "UpdateComentario", ex );
            }
        }
        private IActionResult ErrorMessage( string nameFunction, Exception ex ) {
            _logger.LogError( $"Ocurrio un error dentro de la funcion {nameFunction}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

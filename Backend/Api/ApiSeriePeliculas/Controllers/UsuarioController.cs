using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/usuario" )]
    [ApiController]
    public class UsuarioController : ControllerBase {
        IRepositoryWrapper _repository;
        IMapper _mapper;
        ILoggerManager _logger;
        public UsuarioController( IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger ) {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult GetAllUsuarios( [FromQuery]UserParameters parameters) {

            try {
                var usuarios = _repository.Usuario.GetAll(parameters);

                var metadata = new {
                    usuarios.TotalCount,
                    usuarios.PageSize,
                    usuarios.CurrentPage,
                    usuarios.TotalPages,
                    usuarios.HasNext,
                    usuarios.HasPrevious
                };

                Response.Headers.Add( "X-Pagination", JsonConvert.SerializeObject( metadata ) );
                _logger.LogInfo( $"Se han obtenido {usuarios.TotalCount} series correctamente." );

                // Loginfo de que todo se realizo correctamente
                _logger.LogInfo( "Los datos se han obtenido correctamente." );
                // Crea el mapeo para que retorne el dto solamente de los datos que tiene usuarios
                var usuarioResult = _mapper.Map<IEnumerable<UsuarioDto>>( usuarios );
                return Ok( usuarioResult );
            }
            catch( Exception ex ) {

                // LogError error al hacer get
                _logger.LogError( $"Algo ocurrio en la funcion GetAllUsuarios: {ex.Message}." );
                return StatusCode( 500, "Internal server error" );
            }
        }
        [HttpGet( "{id}")]
        public IActionResult GetUsuarioById( int id ) {
            try {
                var usuario = _repository.Usuario.GetUsuario( id );

                if( usuario == null ) {
                    // LogError el usuario id no esta en la base de datos
                    _logger.LogError( $"El usuario con el id:{id} no se encuentra en la base de datos." );
                    return NotFound();
                }

                // loginfo Retorna usuario con id 
                _logger.LogInfo( $"Se retorna el usuario con el id:{id}." );
                var usuarioResult = _mapper.Map<UsuarioDto>( usuario );

                return Ok( usuarioResult );
            }
            catch( Exception ex ) {

                // Logerror algo salio mal dentro de la funcion getusuariobyid mensaje
                _logger.LogError( $"Algo ocurrio en la funcion GetUsuarioById: {ex.Message}." );
                return StatusCode( 500, "Internal server error" );
            }
        }

        [HttpPost]
        public IActionResult CreateUsuario( [FromBody] UsuarioForCreationDto usuario ) {
            try {
                if( usuario == null ) {
                    // LogError el objeto usuario se envio nulo desde el cliente
                    _logger.LogError( "El usuario se envio nulo desde el cliente." );
                    return BadRequest( "Objeto Usuario es nulo" );
                }
                // Esto toma el UsuarioForCreationDto enviado y se fija si cumple con los requerimientos
                if( !ModelState.IsValid ) {
                    // Logeror objeto usuario enviado desde cliente es invalido
                    _logger.LogError( "El objeto usuario enviado desde el cliente es invalido." );
                    return BadRequest( "Objeto Usuario es invalido" );
                }

                var usuarioEntity = _mapper.Map<Usuario>( usuario );

                usuarioEntity.FechaCreacion = DateTime.Now;
                usuarioEntity.TipoUsuarioId = 1;

                _repository.Usuario.CreateUsuario( usuarioEntity );
                _repository.Save();
                _logger.LogInfo( $"El usuario: {usuarioEntity.User} se ha creado con exito." );

                var createdUsuario = _mapper.Map<UsuarioDto>( usuarioEntity );
                return Created( "Creado con exito", createdUsuario );
                //return NoContent();
                // return CreatedAtRoute( "UsuarioById", new { id = usuarioEntity.Id } );
            }
            catch( Exception ex ) {

                // LogError algo sucedio dentro de la funcion CreateUsuario mensaje
                _logger.LogError( $"Algo ocurrio en la funcion CreateUsuario: {ex.Message}." );
                return StatusCode( 500, "Internal server error" );
            }
        }

        [HttpPut( "{id}" )]
        public IActionResult UpdateUsuario( int id, [FromBody] UsuarioForUpdateDto usuario ) {
            try {
                if( usuario is null ) {
                    // ErrorLog el objeto usuario es null
                    _logger.LogError( "El usuario se envio nulo desde el cliente." );

                    return BadRequest( "Usuario object is null" );
                }

                if( !ModelState.IsValid ) {
                    // Errorlog el objeto usuario es invalido
                    _logger.LogError( "El objeto usuario enviado desde el cliente es invalido." );
                    return BadRequest( "Invalid model object" );
                }

                var usuarioEntity = _repository.Usuario.GetUsuario( id );

                if( usuarioEntity is null ) {
                    // Eror log el usuario con el id no se encuentra en la db
                    _logger.LogError( $"El usuario con el id: {id} no se encuentra en la base de datos." );
                    return NotFound();
                }

                // Mapea los valore de usuario a usuarioEntity almacenando los valores en usuarioEntity
                _mapper.Map( usuario, usuarioEntity );

                _repository.Usuario.UpdateUsuario( usuarioEntity );
                _repository.Save();
                _logger.LogInfo( $"El usuario se ha editado con exito." );

                return NoContent();
            }
            catch( Exception ex ) {
                // Eror log algo paso en la funcion UpdateUsuario mensaje
                _logger.LogError( $"Algo ocurrio en la funcion UpdateUsuario: {ex.Message}." );
                return StatusCode( 500, "Internal server error" );

            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id ) {
            try {
                var usuario = _repository.Usuario.GetUsuario( id );

                if(usuario is null ) {
                    // Error log el usario id no se encuentra en la base de datos
                    _logger.LogError( $"El usuario con el id: {id} no se encuentra en la base de datos." );
                    return NotFound();
                }
                _logger.LogInfo( $"El usuario: {usuario.User} se ha borrado con exito." );
                _repository.Usuario.DeleteUsuario( usuario );

                _repository.Save();
                

                return NoContent();
            }
            catch( Exception ex ) {
                // Error log algo sucedio en la funcion DeleteUsuario mensaje
                _logger.LogError( $"Algo ocurrio en la funcion DeleteUsuario: {ex.Message}." );
                return StatusCode( 500, "Server internal error" );
            }
        }
    }
}

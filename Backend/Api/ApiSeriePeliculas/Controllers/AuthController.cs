using ApiSeriePeliculas.Core.Services;
using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/auth" )]
    [ApiController]
    public class AuthController : ControllerBase {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private LoginService loginService;
        private IConfiguration _configuration;
        public AuthController( ILoggerManager logger, IRepositoryWrapper repository, IConfiguration configuration, IMapper mapper ) {
            _logger = logger;
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
            loginService = new LoginService( repository, logger, configuration );
        }

        [HttpPost]
        public IActionResult Login( [FromBody] Login login ) {

            try {
                Usuario usuario;
                if( login == null ) {
                    _logger.LogError( "Peticion invalidad, el Login es null" );
                    return BadRequest( "Invalid cliente request" );
                }

                if( ( usuario = loginService.HasLogued( login ) ) != null ) {
                    _logger.LogInfo( "El usuario se ha logueado con exito" );

                    var result = _mapper.Map<UsuarioForLoginDto>( usuario );
                    return Ok( new AuthenticatedResponse { Usuario = result, Token = loginService.CreateToken() } );
                }

                return Unauthorized();
            }
            catch( Exception ex ) {

            
                return ErrorMessage( "Login", ex );
            }
           

            
        }

        [HttpPost("{token}")]
        public IActionResult ValidateLogin(string token ) {
            if( token == null ) {
                _logger.LogError( "El token enviado para validar es null" );
                return BadRequest(false);
            }
            if( loginService.ValidateToken( token ) ) {
                _logger.LogInfo( "El token es valido" );

                return Ok( true );
            }

            return Unauthorized( false );
        }

        [HttpPut]
        [Authorize]
        public IActionResult ChangePassword(LoginChangePasswordDto login ) {
            try {
                if(login is null ) {
                    _logger.LogError( "No se han enviado datos" );
                    return BadRequest( "No se han enviado datos" );
                }

                Usuario usuario;
                if((usuario = loginService.HasLogued(new Login(login.UserName, login.Password))) != null ) {
                    
                    if(loginService.ChangePassword( login ) ) {
                        _logger.LogInfo( "La password ha sido cambiada correctamente." );
                        return Ok();
                    } 
                }
                _logger.LogError( "La clave no se ha podido cambiar." );
                return BadRequest( "La clave no se ha podido cambiar." );
            }
            catch( Exception ex ) {
                return ErrorMessage( "ChangePassword", ex );
            }
        }

        private IActionResult ErrorMessage( string nameFunction, Exception ex ) {
            _logger.LogError( $"Ocurrio un error dentro de la funcion {nameFunction}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

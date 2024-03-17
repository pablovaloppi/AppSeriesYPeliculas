using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ApiSeriePeliculas.Core.Services
{
    public class LoginService
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
        private IConfiguration _configuration;
        private Usuario? _usuario;

        private AuthenticatedResponse _response;

        public LoginService( IRepositoryWrapper repository, ILoggerManager logger, IConfiguration configuration ) {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }
        public Usuario? HasLogued( Login login ) {
            _usuario = _repository.Usuario.GetUsuarioByUsername( login.UserName );

            if( _usuario == null ) {
                _logger.LogError( $"El usuario: {login.UserName} no se encuentra en la DB" );
                return null;
            }

            if( String.Equals( _usuario.Password, login.Password ) ) {
                _logger.LogInfo( $"El usuario: {login.UserName} se ha logueado correctamente" );
                return _usuario;
            }
            _logger.LogError( $"La password es incorrecta" );
            return null;
        }

        public bool ChangePassword(LoginChangePasswordDto login ) {
            if(login.NewPassword.Length <= 0 ) {
                _logger.LogError( "New password esta vacia" );
                return false;
            }

            Usuario usuario;
            if((usuario = HasLogued(new Login(login.UserName, login.Password))) != null ) {

                usuario.Password = login.NewPassword;

                _repository.Usuario.UpdateUsuario( usuario );
                _repository.Save();

                _logger.LogInfo( "Se ha guardado el usuario con la clave nueva." );
                return true;
            }
            _logger.LogError( "No se ha podido logear el usuario." );
            return false;
        }
        public string CreateToken() {
            var secretKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration.GetSection( "Jwt:Key" ).Value ) );
            var signinCredentials = new SigningCredentials( secretKey, SecurityAlgorithms.HmacSha256 );


            var claims = new List<Claim> {
                    //new Claim( ClaimTypes.Name, _usuario.User),
                    new Claim( ClaimTypes.Role, _repository.Usuario.GetRoleUser(_usuario))
                };
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration[ "Issuer" ],
                audience: _configuration[ "Audience" ],
                claims: claims,
                expires: DateTime.Now.AddSeconds( 3600 ),
                signingCredentials: signinCredentials );

            var tokenString = new JwtSecurityTokenHandler().WriteToken( tokenOptions );

            return tokenString;
            // return new AuthenticatedResponse { Token = tokenString };
        }

        public bool ValidateToken( string token ) {
            try {

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken( token, validationParameters, out validatedToken );

                _logger.LogInfo( "El token es valido" );
                return true;
            }
            catch( Exception ex ) {

                _logger.LogError( $"Error al validar token: {ex}" );
                return false;
            }
        }

        private TokenValidationParameters GetValidationParameters() {
            return new TokenValidationParameters {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration.GetSection( "Jwt:Issuer" ).Value,
                ValidAudience = _configuration.GetSection( "Jwt:Audience" ).Value,
                IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration.GetSection( "Jwt:Key" ).Value ) )
            };
        }
    }
}

using ApiSeriePeliculas.Core.Services;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private ILoggerManager _logger;
        private UploadService _uploadService;
        public UploadController(ILoggerManager logger)
        {
            _logger = logger;
            _uploadService = new UploadService( _logger );
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload() {
            try {
                var file = Request.Form.Files[ 0 ];
                var folderName = Path.Combine( "Resources", "Images" ); // Resources/Iamges
                var pathToSave = Path.Combine( Directory.GetCurrentDirectory(), folderName ); // devuelve la direccion del dir/Resources/Images 

                if( file.Length > 0 ) {
                    var fileName = ContentDispositionHeaderValue.Parse( file.ContentDisposition ).FileName.Trim( '"' ); 
                    var fullPath = Path.Combine( pathToSave, fileName );
                    var dbPath = Path.Combine( folderName, fileName );

                    if( !_uploadService.IsImage( fileName )){
                        _logger.LogError( "El archivo no tiene una extension de imagen valida." );
                        return BadRequest( "El archivo no tiene una extension de imagen valida." );
                    }

                    var stream = new FileStream( fullPath, FileMode.Create );
                    
                    file.CopyTo( stream );
               
                    _logger.LogInfo( $"El file {fileName} se guardo correctamete." );

                    return Ok( new { dbPath } );
                }

                _logger.LogError( "El tamaño del file es negativo.");
                return BadRequest("El archivo esta vacio o dañado.");

             }
            catch( Exception ex ) {

                return ErrorMessage( "Upload", ex );
            }
        }

        private IActionResult ErrorMessage( string nameFunction, Exception ex ) {
            _logger.LogError( $"Ocurrio un error dentro de la funcion {nameFunction}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

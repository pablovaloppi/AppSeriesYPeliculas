using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/pais" )]
    [ApiController]
    public class PaisController : ControllerBase {
        private IRepositoryWrapper _repository;
        private ILoggerManager _loger;
        private IMapper _mapper;
        public PaisController( IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper ) {
            _loger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] 
        public IActionResult GetAllPais() {
            try {
                var Nombre = _repository.Pais.GetAll();

                if(Nombre is null ) {
                    _loger.LogError( "No se han encontrado Nombre." );
                    return NotFound();
                }

                _loger.LogInfo( "Se han obtenido correctamente todos los Nombre" );

                var result = _mapper.Map<IEnumerable<PaisDto>>( Nombre );

                return Ok( result );
            }
            catch( Exception ex ) {
                _loger.LogError( $"Ha ocurrido un error en la funcion GetAllPais: {ex.Message}" );
                return BadRequest( "Ha ocurrido un error en GetAllPais" );
            }
        }
    }
}

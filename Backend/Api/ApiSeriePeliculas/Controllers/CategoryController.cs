using AutoMapper;
using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiSeriePeliculas.Controllers
{
    [Route( "api/category" )]
    [ApiController]
    public class CategoryController : ControllerBase {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public CategoryController( ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper ) {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategory( [FromQuery] CategoryParameters parameters ) {
            try {
                var category = _repository.Category.GetAll( parameters );

                var metadata = new {
                    category.TotalCount,
                    category.PageSize,
                    category.CurrentPage,
                    category.TotalPages,
                    category.HasNext,
                    category.HasPrevious
                };

                Response.Headers.Add( "X-Pagination", JsonConvert.SerializeObject( metadata ) );
                _logger.LogInfo( $"Se han obtenido {category.TotalCount} series correctamente." );


                _logger.LogInfo( $"Se han obtenido todas las categorias correctamente." );

                var result = _mapper.Map<IEnumerable<CategoriaDto>>( category );
                return Ok( result );
            }
            catch( Exception ex ) {
                return ErrorMessage( "GetAllCategory", ex );
            }
        }

        [HttpGet( "{id}" )]
        public IActionResult GetCategoryById( int id ) {
            try {
                var categoria = _repository.Category.GetCategoryById( id );

                if( categoria is null ) {
                    _logger.LogError( $"La categoria con el id:{id} no se encuentra en la base de datos" );
                    return NotFound();
                }

                _logger.LogInfo( $"Se retorna la categoria con el id:{id}." );

                var result = _mapper.Map<CategoriaDto>( categoria );
                return Ok( result );
            }
            catch( Exception ex ) {
                return ErrorMessage( "GetCategoryById", ex );
            }
        }


        [HttpPost]
        public IActionResult CreateCategory( [FromBody] CategoriaDto nueva ) {
            try {
                if( nueva.Nombre is null ) {
                    _logger.LogError( "El nombre esta vacio" );
                    return BadRequest( "El nombre esta vacio" );
                }

                var categoria = _mapper.Map<Categoria>( nueva );
                _repository.Category.CreateCategory( categoria );
                _repository.Save();

                _logger.LogInfo( $"La categoria {categoria.Nombre} ha sido creada correctamente" );

                return Ok();

            }
            catch( Exception ex ) {

                return ErrorMessage( "CreateCategory", ex );
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory( int id ) {
            try {
                var category = _repository.Category.GetCategoryById( id );

                if(category is null ) {
                    _logger.LogError( "El id es invalido" );
                    return BadRequest( "El id es invalido" );
                }

                _repository.Category.DeleteCategory( category );
                _repository.Save();

                //_logger.LogInfo( $"La categoria {category.Nombre} se ha borrado exitosamente." );

                return NoContent();
            }
            catch( Exception ex ) {

                return ErrorMessage( "DeleteCategory", ex );
            }
        }

        private IActionResult ErrorMessage( string nameFunction, Exception ex ) {
            _logger.LogError( $"Ocurrio un error dentro de la funcion {nameFunction}: {ex.Message}." );
            return StatusCode( 500, "Server internal error." );
        }
    }
}

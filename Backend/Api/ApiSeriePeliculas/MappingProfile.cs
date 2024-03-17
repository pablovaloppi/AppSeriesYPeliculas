using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace ApiSeriePeliculas
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioForLoginDto>();
            CreateMap<UsuarioForCreationDto, Usuario>();
            CreateMap<UsuarioForUpdateDto, Usuario>();


            CreateMap<Serie, SerieDto>();
            CreateMap<SerieDto, Serie>();
            CreateMap<SerieForUpdate, Serie>();
            CreateMap<SerieDtoForCreation, Serie>();

            CreateMap<Pelicula, PeliculaDto>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<Pais, PaisDto>();

            CreateMap<Comentario, ComentarioDto>();
            CreateMap<ComentarioDto, Comentario>();
            CreateMap<Comentario, ComentarioCreationDto>();
            CreateMap<ComentarioCreationDto, Comentario>();
            CreateMap<ComentarioUpdateDto, Comentario>();
            CreateMap<Comentario, ComentarioUpdateDto>();

            CreateMap<SeriesFavoritas, SerieFavoritaDto>();
            CreateMap<SerieFavoritaDto, SeriesFavoritas>();
        }
    }
}

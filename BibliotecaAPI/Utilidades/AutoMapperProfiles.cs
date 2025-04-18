using AutoMapper;
using BibliotecaAPI.DTO;
using BibliotecaAPI.Entidades;

namespace BibliotecaAPI.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(dto => dto.NombreCompleto,
                    config => config.MapFrom(autor => MapearNombreYApellidoAutor(autor)));

            CreateMap<Autor, AutorConLibrosDTO>()
                .ForMember(dto => dto.NombreCompleto,
                    config => config.MapFrom(autor => MapearNombreYApellidoAutor(autor)));

            CreateMap<AutorCreacionDTO, Autor>();

            CreateMap<Autor, AutorPatchDTO>().ReverseMap();
            CreateMap<AutorCreacionDTOConFoto, Autor>()
                .ForMember(ent => ent.Foto, config => config.Ignore());
            CreateMap<AutorLibro, LibroDTO>()
                .ForMember(dto => dto.Id, config => config.MapFrom(et => et.LibroId))
                .ForMember(dt => dt.Titulo, conf => conf.MapFrom(e => e.Libro!.Titulo));

            CreateMap<Libro, LibroDTO>();

            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(ent => ent.Autores, config =>
                    config.MapFrom(dto => dto.AutoresIds.Select(id => new AutorLibro { AutorId = id })));

            CreateMap<Libro, LibroConAutoresDTO>();

            CreateMap<AutorLibro, AutorDTO>()
                .ForMember(dto => dto.Id, config => config.MapFrom(ent => ent.AutorId))
                .ForMember(dt => dt.NombreCompleto, 
                    conf => conf.MapFrom(et => MapearNombreYApellidoAutor(et.Autor!)));

            CreateMap<LibroCreacionDTO, AutorLibro>()
                .ForMember(ent => ent.Libro,
                    config => config.MapFrom(dto => new Libro { Titulo = dto.Titulo }));

            CreateMap<ComentarioCreacionDTO,  Comentario>();
            CreateMap<Comentario, ComentarioDTO>()
                .ForMember(dto => dto.UsuarioEmail, config => config.MapFrom(ent => ent.Usuario!.Email));
            CreateMap<ComentarioPatchDTO, Comentario>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>();
        }

        private string MapearNombreYApellidoAutor(Autor autor) => $"{autor.Nombres} {autor.Apellidos}";

    }
}

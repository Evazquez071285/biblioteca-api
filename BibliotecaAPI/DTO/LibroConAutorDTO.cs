namespace BibliotecaAPI.DTO
{
    public class LibroConAutoresDTO: LibroDTO
    {
        public List<AutorDTO> Autores { get; set; } = [];
        //public required string AutorNombre { get; set; }
    }
}

namespace BibliotecaAPI.DTO
{
    public class AutorConLibrosDTO: AutorDTO
    {
        public List<LibroDTO> Libros { get; set; } = [];  //new List<LibroDTO>(); // puse la sintaxis abreviada
    }
}

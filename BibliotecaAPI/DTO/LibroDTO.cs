using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        //public int AutorId { get; set; }
    }
}

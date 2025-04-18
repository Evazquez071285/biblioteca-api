using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class ComentarioCreacionDTO
    {
        [Required]
        public required string Cuerpo { get; set; }
    }
}

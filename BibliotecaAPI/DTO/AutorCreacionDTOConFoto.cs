namespace BibliotecaAPI.DTO
{
    public class AutorCreacionDTOConFoto: AutorCreacionDTO
    {
        public IFormFile? Foto {  get; set; }
    }
}

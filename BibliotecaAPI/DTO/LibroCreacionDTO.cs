﻿using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class LibroCreacionDTO
    {
        [Required]
        [StringLength(250, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos")]
        public required string Titulo { get; set; }
        public List<int> AutoresIds { get; set; } = [];

        //public int AutorId { get; set; }
    }
}

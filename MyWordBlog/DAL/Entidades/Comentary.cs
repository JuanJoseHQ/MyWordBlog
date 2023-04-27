﻿using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class Comentary : Entity
    {
        [Display(Name = "Comentario")]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
        public DateTime? DatePublication { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class UserRegistred : Entity
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Correo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string? Correo { get; set; }

        [Display(Name = "Numero")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public long? Number { get; set; }

        [Display(Name = "Tipo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public int? Rol { get; set; }

        [Display(Name = "UsuarioLogin")]
        public UserLogin UserLogin { get; set; }

        [Required]
        public Guid UserLoginId { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comentary> Comentaries { get; set; }


    }
}
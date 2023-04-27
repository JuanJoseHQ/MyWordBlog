using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class UserLogin : Entity
    {
        [Display(Name = "Usuario")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string User { get; set; }

        [Display(Name = "Contraseña")]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Password { get; set; }

        [Display(Name = "UsuarioRegistrado")]
        public ICollection<UserRegistred> UsersRegistred { get; set; }
    }
}


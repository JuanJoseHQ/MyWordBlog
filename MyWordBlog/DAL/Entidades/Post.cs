using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyWordBlog.DAL.Entidades
{
    public class Post : Entity
    {
        [Display(Name = "Titulo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Title { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(3000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Desctipton { get; set; }
        public int? CantLikes { get; set; }
        public int? CantDisLikes { get; set; }


        public ICollection<Comentary> Comentaries { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyWordBlog.DAL.Entidades
{
    public class Post : Entity
    {
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {100} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Title { get; set; }

        [MaxLength(3000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
        public string? Author { get; set; }
      
        public int? CountLikes { get; set; }
        public int? CountDisLikes { get; set; }

        public ICollection<Commentary>? Commentaries { get; set; }
    }
}

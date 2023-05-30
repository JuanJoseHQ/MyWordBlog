using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWordBlog.DAL.Entidades
{
    public class Comentary : Entity
    {
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Description { get; set; }
        public DateTime? DatePublication { get; set; }

        public string? Author { get; set; }

        public Post Post { get; set; }

        public Guid PostId { get; set; }

    }
}

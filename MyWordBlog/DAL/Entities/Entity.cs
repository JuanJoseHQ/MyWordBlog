using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? PublicationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}

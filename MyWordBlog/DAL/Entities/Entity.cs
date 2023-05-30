using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}

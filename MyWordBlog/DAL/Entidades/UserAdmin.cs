using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class UserAdmin : UserRegistred
    {
        [Display(Name = "Fecha de Registro")]
        public DateTime? S { get; set; }
    }
}

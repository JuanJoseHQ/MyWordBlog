using System.ComponentModel.DataAnnotations;

namespace MyWordBlog.DAL.Entidades
{
    public class UserCommon : UserRegistred
    {
        [Display(Name = "Fecha de Registro")]
        public DateTime? DateRegistred { get; set; }
    }
}

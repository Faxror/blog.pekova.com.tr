using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class RolViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz!")]
        public string Name { get; set; }
    }
}

using E_commerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class person: IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "FullName")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="name must be form 3 to 50 characters")]
        public string Name { get; set; }


        [Display(Name ="Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string bio { get; set; }


        [Display(Name = "profile picture url")]
        [Required(ErrorMessage = "picture url is required")]
        public string picUrl { get; set; }
    }
}

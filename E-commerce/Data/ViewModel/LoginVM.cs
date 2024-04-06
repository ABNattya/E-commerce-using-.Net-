using System.ComponentModel.DataAnnotations;

namespace E_commerce.Data.ViewModel
{
    public class LoginVM
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email is rquired")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

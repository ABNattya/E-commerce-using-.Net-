using System.ComponentModel.DataAnnotations;

namespace E_commerce.Data.ViewModel
{
    public class RegisterVM
    {

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "FullName is rquired")]
        public string FullName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email is rquired")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password is not match")]
        public string ConfirmPassword { get; set; }
    }
}

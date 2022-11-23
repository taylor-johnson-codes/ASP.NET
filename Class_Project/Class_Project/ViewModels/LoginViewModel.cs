using System.ComponentModel.DataAnnotations;

namespace Class_Project.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        //[Display(Name = "Password")]  // same as variable name so not needed
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }  // will show up as check-box; false by default
    }
}

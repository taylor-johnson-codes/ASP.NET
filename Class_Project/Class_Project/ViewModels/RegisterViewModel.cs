using System.ComponentModel.DataAnnotations;

namespace Class_Project.ViewModels
{
    public class RegisterViewModel : LoginViewModel  // inherit for username and password that was already created there
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Display(Name = "Phone number")]
        public string? Phone { get; set; }
    }
}

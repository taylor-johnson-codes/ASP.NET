using System.ComponentModel.DataAnnotations;

namespace Class_Project.ViewModels
{
    public class RegisterViewModel : LoginViewModel  // inherit for username and password that was already created there
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string? LastName { get; set; }

        //[Display(Name = "Email")]  // same as variable name so not needed
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}

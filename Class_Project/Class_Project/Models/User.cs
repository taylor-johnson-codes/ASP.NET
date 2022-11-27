using Microsoft.AspNetCore.Identity;  // for inheriting built-in IdentityUser class
using System.ComponentModel.DataAnnotations;

namespace Class_Project.Models
{
    public class User : IdentityUser
    // Ctrl+click to see what's built-in to IdentityUser class; it has ID built-in
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string? LastName { get; set; }
    }
}

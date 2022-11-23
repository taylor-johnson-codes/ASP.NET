using Microsoft.AspNetCore.Identity;  // for inheriting built-in IdentityUser class

namespace Class_Project.Models
{
    public class User : IdentityUser
    // Ctrl+click to see what's built-in to IdentityUser class; it has ID built-in
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

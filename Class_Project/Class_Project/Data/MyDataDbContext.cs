// Steps to add Entity Framework Core to the project:
// Installed SQLite NuGet package by clicking Tools, NuGet Package Manager, Manage NuGet Packages for Solution
// Browse and select Microsoft.EntityFrameworkCore.Sqlite, choose the project and version, click Install
// Now the project has many more C# classes available for use

using Class_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  // for IdentityDbContext<User>

namespace Class_Project.Data
{
    // before implementing users with IdentityDbContext:
    /*
    // my class needs to inherit the built-in DbContext class
    // this class is used in the "context" variable in Program.cs
    // public class MyDataDbContext : DbContext
    */

    public class MyDataDbContext : IdentityDbContext<User>  // need to install Identity NuGet package to use built-in IdentityDbContext class
    {
        // create constructor that accepts parameters (done once per project for set up)
        public MyDataDbContext(DbContextOptions<MyDataDbContext> options) : base(options)  // pass options to base class constructor
        {
            // nothing needed in here
            // this constructor is just needed to call the base instructor with parameter
        }

        // tables (aka entities) we want to work with
        // each row in the table represents one entry (one instructor or one student)
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        // alternative code:
        //public DbSet<Student> Students => Set<Student>();
    }
}

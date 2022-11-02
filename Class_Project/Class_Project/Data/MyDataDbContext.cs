using Class_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Class_Project.Data
{
    // my class needs to inherit the built-in DbContext class
    public class MyDataDbContext : DbContext
    {
        // do once per project to set up
        // create constructor that accepts parameters
        public MyDataDbContext(DbContextOptions<MyDataDbContext> options) : base(options)  // pass options to base class constructor
        {
            // nothing needed in here
            // this constructor is just needed to call the base instructor with parameter
        }

        // tables (aka entities) we want to work with
        // each row in the table represents one instructor or one student (one entry)
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        // alternative code:
        //public DbSet<Student> Students => Set<Student>();
    }
}

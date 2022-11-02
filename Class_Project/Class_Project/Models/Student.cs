// A model contains business logic, validation, and database access logic
// Models are simple POCO C# classes in .cs files
// POCO: Plain Old CLR Objects; class that doesn't inherit functionality of any specific framework

// Create a Models folder in the project
// Right click on folder, Add Class

namespace Class_Project.Models
{
    public enum Major { Comp_Science, IT, Math, Other }

    // Controller for this class will use the class name and append "Controller": StudentContoller
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsVeteran { get; set; }
        public double? GPA { get; set; }  // ? allows null value
        public Major Major { get; set; }
    }
}

namespace Class_Project.Models
{
    public enum Major { Comp_Science, IT, Math, Other }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isVeteran { get; set; }
        public double? GPA { get; set; }  // ? allows null value
        public Major Major { get; set; }
    }
}

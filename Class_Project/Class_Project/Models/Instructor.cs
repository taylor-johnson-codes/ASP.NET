using System.ComponentModel.DataAnnotations;

namespace Class_Project.Models
{
    public enum Level { Instructor, AssistantProfessor, AssociateProfessor, FullProfessor }

    public class Instructor
    {
        [Display(Name="Instructor ID: ")]
        public int InstructorId { get; set; }

        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        
        [Display(Name= "Last Name: ")]
        public string LastName { get; set; }
        
        [Display(Name="Is Tenured?: ")]
        public bool IsTenured { get; set; }  // "bool?" would allow for null value in addition to true/false
        
        [Display(Name="Position: ")]
        public Level Position { get; set; }

        [Display(Name = "Hire Date: ")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}

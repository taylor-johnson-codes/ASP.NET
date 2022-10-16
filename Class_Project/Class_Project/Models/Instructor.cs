using System.ComponentModel.DataAnnotations;

namespace Class_Project.Models
{
    public enum Level { Instructor, AssistantProfessor, AssociateProfessor, FullProfessor }

    public class Instructor
    {
        // The [Display] lines here help with the view/cshtml file (Display Data Annotations)
        // The view file will use label tags (tag helpers) that link up with the [Display] lines here
        // view/cshtml example: <label asp-for="InstructorId"></label>

        // List of all Data Annotations:
        // https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0

        [Display(Name = "Instructor ID")]
        public int InstructorId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Is Tenured?")]
        public bool IsTenured { get; set; }  
        // "bool?" will allow for a null value in addition to true/false values, but won't result in a check-box in the view
        
        [Display(Name = "Position")]
        public Level Position { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateOnly HireDate { get; set; }
    }
}

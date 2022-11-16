// This model is mapped to a database table via MyDataDbContext.cs in the Data folder

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

        // List of all Validation attributes:
        // https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0

        [Required(ErrorMessage = "Enter ID")]
        [Display(Name = "Instructor ID")]
        public int InstructorId { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [StringLength(20, ErrorMessage = "Can't use more than 20 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [StringLength(20, ErrorMessage = "Can't use more than 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Needs response")]
        [Display(Name = "Is Tenured?")]
        public bool IsTenured { get; set; }
        // "bool?" will allow for a null value in addition to true/false values, but won't result in a check-box in the view

        [Required(ErrorMessage = "Enter position")]
        [Display(Name = "Position")]
        public Level Position { get; set; }

        [Required(ErrorMessage = "Enter hire date")]
        [Range(typeof(DateTime), "01/01/2020", "12/31/2022")]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Instructor photo")]
        public byte[]? ImageDataForInst { get; set; }
        // ? allows for null
    }
}

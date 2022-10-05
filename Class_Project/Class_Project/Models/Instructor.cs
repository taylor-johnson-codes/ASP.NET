namespace Class_Project.Models
{
    public enum Level { Instructor, AssistantProfessor, AssociateProfessor, FullProfessor }

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsTenured { get; set; }  // ? allows for null value, so the value can be true, false, or null
        public Level Position { get; set; }
    }
}

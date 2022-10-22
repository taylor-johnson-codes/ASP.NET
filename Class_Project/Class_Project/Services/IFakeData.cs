using Class_Project.Models;

namespace Class_Project.Services
{
    // Add a leading "I" to the name when creating an interface
    public interface IFakeData
    {
        // provide list as service
        public List<Instructor> InstructorsList { get; set; }
    }
}

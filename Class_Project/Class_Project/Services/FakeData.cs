// NOT NEEDED AFTER ADDING ENTITY FRAMEWORK CORE (DATABASE) TO PROJECT

/*
// Creating an instance via a service that can be used/persists for the duration of the application
// When the application restarts, the data is lost

using Class_Project.Models;

namespace Class_Project.Services
{
    // needs to implement the interface created for this class
    public class FakeData : IFakeData
    {
        public List<Instructor> InstructorsList { get; set; }

        // hard-code data into constructor
        public FakeData()
        {
            // make an instance of the list
            InstructorsList = new List<Instructor>();

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 1,
                FirstName = "Alex",
                LastName = "Mezei",
                IsTenured = false,
                Position = Level.AssistantProfessor,
                HireDate = new DateTime(2010, 10, 10)
            }); ;

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 2,
                FirstName = "Xuguang",
                LastName = "Chen",
                IsTenured = true,
                Position = Level.AssociateProfessor,
                HireDate = new DateTime(2020, 2, 20)
            });

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 3,
                FirstName = "Richard",
                LastName = "Beer",
                IsTenured = true,
                Position = Level.FullProfessor,
                HireDate = new DateTime(2003, 3, 30)
            });
        }
    }
}
*/
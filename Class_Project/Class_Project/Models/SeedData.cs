using Class_Project.Data;

namespace Class_Project.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(MyDataDbContext myDbContext)
        {
            if (myDbContext.Instructors.Count() == 0)
            {
                List<Instructor> InstructorsList = new List<Instructor>();
                //InstructorsList = new List<Instructor>();

                InstructorsList.Add(new Instructor()
                {
                    InstructorId = 1,
                    FirstName = "Alex",
                    LastName = "Mezei",
                    IsTenured = false,
                    Position = Level.AssistantProfessor,
                    //HireDate = DateOnly.Parse("10/10/2010"),
                    HireDate = new DateTime(2010, 10, 10)
                }); ;

                InstructorsList.Add(new Instructor()
                {
                    InstructorId = 2,
                    FirstName = "Xuguang",
                    LastName = "Chen",
                    IsTenured = true,
                    Position = Level.AssociateProfessor,
                    //HireDate = DateOnly.Parse("2/20/2020")
                    HireDate = new DateTime(2020, 2, 20)
                });

                InstructorsList.Add(new Instructor()
                {
                    InstructorId = 3,
                    FirstName = "Richard",
                    LastName = "Beer",
                    IsTenured = true,
                    Position = Level.FullProfessor,
                    //HireDate = DateOnly.Parse("3/30/2003")
                    HireDate = new DateTime(2003, 3, 30)
                });

                myDbContext.AddRange(InstructorsList);

                myDbContext.Students.Add(new Student()
                {
                    // don't have to specify ID, it will automatically assign an ID
                    FirstName = "Taylor",
                    LastName = "Johnson",
                    IsVeteran = true,  
                });
                // ********************************copy/paste rest from Controller

                myDbContext.SaveChanges();
            }
        }
    }
}

// putting fake data into the database so it's not empty
// use a static class so it can be used without creating an instance of it

using Class_Project.Data;

namespace Class_Project.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(MyDataDbContext myDbContext)
        {
            if (myDbContext.Instructors.Count() == 0)
            {
                // ------------------------- INSTRUCTOR DATA (with list) -------------------------

                List<Instructor> InstructorsList = new List<Instructor>();

                InstructorsList.Add(new Instructor()
                {
                    // if an ID isn't assigned, the database will automatically assign an ID
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

                myDbContext.AddRange(InstructorsList);

                myDbContext.SaveChanges();
            }

            // ------------------------- STUDENT DATA (without list) -------------------------

            if (myDbContext.Students.Count() == 0)
            {
                myDbContext.Students.Add(new Student()
                {
                    // if an ID isn't assigned, the database will automatically assign an ID
                    FirstName = "Taylor",
                    LastName = "Johnson",
                    IsVeteran = true,
                    GPA = 3.9,
                    Major = Major.Comp_Science
                });

                myDbContext.Students.Add(new Student()
                {
                    FirstName = "Matt",
                    LastName = "Dunaway",
                    IsVeteran = true,
                    GPA = 3.0,
                    Major = Major.Math
                });

                myDbContext.Students.Add(new Student()
                {
                    FirstName = "Kayla",
                    LastName = "Heart",
                    IsVeteran = false,
                    GPA = 2.6,
                    Major = Major.Other
                });

                myDbContext.SaveChanges();
            }
        }
    }
}

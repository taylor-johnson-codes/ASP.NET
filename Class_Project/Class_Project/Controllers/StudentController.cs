using Class_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    // the name StudentController comes from the Student class; just add "Controller" onto the class name
    public class StudentController : Controller  
    {
        // attribute routing is shown here for learning purposes only; we'll be focusing on conventional routing in Program.cs

        //[Route("Test")]  // attribute routing example; localhost:####/Test
        //[Route("Taylor")]  // both are for the Index action; localhost:####/Taylor
        public IActionResult Index()
        {
            return Content("Welcome from Student controller Index action");
        }

        //[Route("/")]  // same as default page
        //[Route("{id}")]
        public IActionResult Show(int id)  // given an id parameter, normally we'd search a database, but we don't have a database yet
        {
            Student student = new Student();

            if (id==1)
            {
                student.FirstName = "Mac";
                student.LastName = "Aroni";
                student.GPA = 3.0;
                student.IsVeteran = false;
                student.Major = Major.Other;
            }
            else
            {
                student.FirstName = "Taylor";
                student.LastName = "Johnson";
                student.GPA = 3.9;
                student.IsVeteran = true;
                student.Major = Major.Comp_Science;
            }

            ViewBag.SMU_student = student;
            // ViewBag is a dynamic object so you can put anything in it
            // used to display info on the View .cshtml page

            return View();
            // To create a View, right click anywhere inside of the action method,
            // click Add View, choose Razor View (NOT the empty option), click Add, uncheck Create & uncheck Use, click Add
            // A Views folder with a .cshtml file is automatically created
        }
    }
}

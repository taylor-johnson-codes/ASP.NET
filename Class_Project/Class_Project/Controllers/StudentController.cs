using Class_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    public class StudentController : Controller
    {
        [Route("Test")]  // attribute routing; localhost:####/Test
        [Route("Taylor")]  // both are for the Index action; localhost:####/Taylor
        public IActionResult Index()
        {
            return Content("Welcome from Student controller Index action");
        }

        [Route("/")]  // same as default page
        [Route("{id}")]
        public IActionResult Show(int id)
        {
            // given an ID, normally I'd search a database for the info; we don't have a database yet

            Student student = new Student();

            if (id==1)
            {
                student.FirstName = "Matthew";
                student.LastName = "Dunaway";
                student.GPA = 3.0;
                student.isVeteran = false;
                student.Major = Major.Other;
            }
            else
            {
                student.FirstName = "Taylor";
                student.LastName = "Johnson";
                student.GPA = 3.9;
                student.isVeteran = true;
                student.Major = Major.Comp_Science;
            }

            ViewBag.SMU_student = student;
            // ViewBag is a dynamic object so you can put anything in it

            return View();
        }
    }
}

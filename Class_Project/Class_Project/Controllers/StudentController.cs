using Class_Project.Data;
using Class_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    // the name StudentController comes from the Student class; just add "Controller" onto the class name
    public class StudentController : Controller  
    {
        // inject EF/DbContext
        private MyDataDbContext _context;
        public StudentController(MyDataDbContext existingContext)
        {
            _context = existingContext;
        }

        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult ViewDetails(int id)
        {
            // search database for the student
            Student student = _context.Students.FirstOrDefault(st => st.StudentId == id);
            
            // if NOT found
            if (student == null)
                return NotFound();

            // if found
            return View();
        }

        // GET request to display form
        public IActionResult Add()
        {
            return View();
        }

        // POST request
        [HttpPost]
        public IActionResult Add(Student student)
        {
            //without validation example

            // add student to database
            _context.Students.Add(student);  // _context.Add(student);  VS knows student is Student so can leave that out
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // commented the rest out to implement EF

        // attribute routing is shown here for learning purposes only; we'll be focusing on conventional routing in Program.cs

        //[Route("Test")]  // attribute routing example; localhost:####/Test
        //[Route("Taylor")]  // both are for the Index action; localhost:####/Taylor
        //public IActionResult Index()
        //{
        //    return Content("Welcome from Student controller Index action");
        //}

        //[Route("/")]  // same as default page
        //[Route("{id}")]
        //public IActionResult Show(int id)  // given an id parameter, normally we'd search a database, but we don't have a database yet
        //{
        //    Student student = new Student();

        //    if (id==1)
        //    {
        //        student.FirstName = "Mac";
        //        student.LastName = "Aroni";
        //        student.GPA = 3.0;
        //        student.IsVeteran = false;
        //        student.Major = Major.Other;
        //    }
        //    else
        //    {
        //        student.FirstName = "Taylor";
        //        student.LastName = "Johnson";
        //        student.GPA = 3.9;
        //        student.IsVeteran = true;
        //        student.Major = Major.Comp_Science;
        //    }

        //    ViewBag.SMU_student = student;
        //    // ViewBag is a dynamic object so you can put anything in it
        //    // used to display info on the View .cshtml page

        //    return View();
        //    // To create a View, right click anywhere inside of the action method,
        //    // click Add View, choose Razor View (NOT the empty option), click Add, uncheck Create & uncheck Use, click Add
        //    // A Views folder with a .cshtml file is automatically created
        //}
    }
}

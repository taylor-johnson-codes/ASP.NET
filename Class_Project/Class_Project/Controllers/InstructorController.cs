using Class_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorsList = new List<Instructor>();

        // constructor to hard-code data (eventually data will come from a database)
        public InstructorController()
        {
            InstructorsList.Add(new Instructor()
            {
                InstructorId = 10,
                FirstName = "Alex",
                LastName = "Mezei",
                IsTenured = false,
                Position = Level.AssistantProfessor
            });

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 20,
                FirstName = "Xuguang",
                LastName = "Chen",
                IsTenured = true,
                Position = Level.AssociateProfessor,
            });

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 30,
                FirstName = "Richard",
                LastName = "Beer",
                IsTenured = true,
                Position = Level.FullProfessor,
            });
        }

        // display a list of all the instructors
        public IActionResult Index()
        {
            return View(InstructorsList);  // pass the list in this file to the view file
        }

        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", InstructorsList);  // doesn't show the same URL
        }

        public IActionResult DisplayAll()
        {
            return View("Index", InstructorsList);  // shows the same URL
        }

        // display the details of one instructor
        public IActionResult ShowDetails(int id)  // eventually we will search for the id in the database
        {
            Instructor? oneInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // lambda expression
            // ? so null can be a result

            //if (oneInstr == null)
            //    return NotFound();
            //else
            //    return Content("found");

            return View(oneInstr);  // return the found instructor via a view
        }
    }
}

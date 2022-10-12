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

        // responds to get requests
        public IActionResult Add()
        {
            return View();
        }

        //model binding
        [HttpPost]  // this view will be shown in routing only when it's a post request, not a get request
        public IActionResult Add(Instructor instr)
        {
            InstructorsList.Add(instr);  // add the new instructor to the full list of instructors
            return View("Index", InstructorsList);  // return the updated list to the Index view
        }

        // responds to get requests
        public IActionResult Edit(int id)
        {
            // when we have a database, search it for id

            // search the list we have; ? allow for null if not found
            Instructor? foundInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);

            return View(foundInstr);
        }

        [HttpPost]  // this view will be shown in routing only when it's a post request, not a get request
        public IActionResult Edit(Instructor instrChanges)
        {
            // when we have a database, search it for id

            // update the instructor info to the database/list
            Instructor? foundInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == instrChanges.InstructorId);

            // assuming not null - SEEE SLIDE 13
            // put what's in the form into the database/list
            foundInstr.LastName = instrChanges.LastName;
            foundInstr.FirstName = instrChanges.FirstName;
            foundInstr.IsTenured = instrChanges.IsTenured;
            foundInstr.Position = instrChanges.Position;
            foundInstr.HireDate = instrChanges.HireDate;

            //return RedirectToAction("Index");  // no persistence
            return View("Index", InstructorsList);
        }
    }
}

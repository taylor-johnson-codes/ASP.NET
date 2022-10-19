using Class_Project.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

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
                Position = Level.AssistantProfessor,
                //HireDate = DateOnly.Parse("10/10/2010"),
                HireDate = new DateOnly(2010, 10, 10)
            });;

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 20,
                FirstName = "Xuguang",
                LastName = "Chen",
                IsTenured = true,
                Position = Level.AssociateProfessor,
                //HireDate = DateOnly.Parse("2/20/2020")
                HireDate = new DateOnly(2020, 2, 20)
            });

            InstructorsList.Add(new Instructor()
            {
                InstructorId = 30,
                FirstName = "Richard",
                LastName = "Beer",
                IsTenured = true,
                Position = Level.FullProfessor,
                //HireDate = DateOnly.Parse("3/30/2003")
                HireDate = new DateOnly(2003, 3, 30)
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

        [HttpGet]  // responds to GET requests
        public IActionResult Add()
        {
            return View();
        }

        // Model binding: Controllers and Razor pages work with data that comes from HTTP requests
        // 1st: Data is retrieved from various sources (e.g. a form field in a view)
        // 2nd: Data is provided to controller
        // 3rd: Data is converted to .NET types when needed

        [HttpPost]  // this view will be shown only in response to a POST request, not a get request
        public IActionResult Add(Instructor instr)
        {
            // ADD VALIDATION CODE ~619
            InstructorsList.Add(instr);  // add the new instructor to the full list of instructors
            return View("Index", InstructorsList);  // return the updated list to the Index view
        }

        [HttpGet]  // responds to GET requests
        public IActionResult Edit(int id)
        {
            // when we have a database, search it for an instance with a matching id

            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            return View(foundInstr);
        }

        [HttpPost]  // this view will be shown only in response to a POST request, not a get request
        public IActionResult Edit(Instructor instrChanges)
        {
            // update the instructor info to the database/list
            Instructor? foundInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == instrChanges.InstructorId);

            // ADD VALIDATION CODE ~619

            if (foundInstr != null)
            {
                // put what's in the form into the database/list
                foundInstr.LastName = instrChanges.LastName;
                foundInstr.FirstName = instrChanges.FirstName;
                foundInstr.IsTenured = instrChanges.IsTenured;
                foundInstr.Position = instrChanges.Position;
                foundInstr.HireDate = instrChanges.HireDate;
            }
            else
            {
                // Fix the views to address this concern
            }

            //return RedirectToAction("Index");  // no persistence because we're not setup with database yet
            return View("Index", InstructorsList);  // temporary fix
        }

        //// are you sure form
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    // when we have a database, search it for an instance with a matching id

        //    // search the list we have; "?" allows for null if not found
        //    Instructor? foundInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

        //    if(foundInstr != null)
        //        return View(foundInstr);
        //    else
        //        return NotFound();
        //}

        //// delete confirmed
        //[HttpPost, ActionName("Delete")]
        //public IActionResult Delete(int id)
        //{
        //    // when we have a database, search it for an instance with a matching id

        //    // search the list we have; "?" allows for null if not found
        //    Instructor? foundInstr = InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

        //    // NEED TO WATCH ~555 he went too fast
        //    if (foundInstr != null)
        //    {
        //        InstructorsList.Remove(foundInstr);
        //        return View("Index");
        //    }
        //    else
        //        return NotFound();
        //}
    }
}

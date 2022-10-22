using Class_Project.Models;
using Class_Project.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Class_Project.Controllers
{
    public class InstructorController : Controller
    {
        // moved hard-coded data from the constructor here to the constructor in the FakeData service

        // inject FakeData service
        IFakeData _fakedata;  // local instance
        public InstructorController(IFakeData theFakeDataService)  // need constructor to create the instance
        {
            _fakedata = theFakeDataService;
        }

        // display a list of all the instructors
        public IActionResult Index()
        {
            return View(_fakedata.InstructorsList);  // pass the list in this file to the view file
        }

        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", _fakedata.InstructorsList);  // doesn't show the same URL
        }

        public IActionResult DisplayAll()
        {
            return View("Index", _fakedata.InstructorsList);  // shows the same URL
        }

        // display the details of one instructor
        public IActionResult ShowDetails(int id)  // eventually we will search for the id in the database
        {
            Instructor? oneInstr = _fakedata.InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // lambda expression
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
            _fakedata.InstructorsList.Add(instr);  // add the new instructor to the full list of instructors

            return RedirectToAction("Index");
            //return View("Index", _fakedata.InstructorsList);  // DELETE, THIS WAS B4 SERVICES IMPLEMENTED
        }

        [HttpGet]  // responds to GET requests
        public IActionResult Edit(int id)
        {
            // when we have a database, search it for an instance with a matching id

            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = _fakedata.InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            return View(foundInstr);
        }

        [HttpPost]  // this view will be shown only in response to a POST request, not a get request
        public IActionResult Edit(Instructor instrChanges)
        {
            // update the instructor info to the database/list
            Instructor? foundInstr = _fakedata.InstructorsList.FirstOrDefault(instr => instr.InstructorId == instrChanges.InstructorId);

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

            return RedirectToAction("Index");
            //return View("Index", _fakedata.InstructorsList);  // DELETE, THIS WAS B4 SERVICES IMPLEMENTED
        }

        // confirm the user wants to delete the instructor
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // when we have a database, search it for an instance with a matching id

            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = _fakedata.InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            if (foundInstr != null)
                return View(foundInstr);
            else
                return NotFound();  // built-in action (displays HTTP Error 404)
        }

        // perform delete request
        [HttpPost, ActionName("Delete")]  // this line plus changing the action name fixes the problem of having two matching action names with matching parameters
        public IActionResult PerformDelete(int id)
        {
            // when we have a database, search it for an instance with a matching id

            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = _fakedata.InstructorsList.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            // delete it
            _fakedata.InstructorsList.Remove(foundInstr);  

            // return user to Index view
            return RedirectToAction("Index");
        }
    }
}

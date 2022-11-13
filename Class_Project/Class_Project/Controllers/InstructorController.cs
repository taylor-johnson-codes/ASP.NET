using Class_Project.Data;
using Class_Project.Models;
//using Class_Project.Services;  // moved data from FakeData service to SeedData database
using Microsoft.AspNetCore.Mvc;
using Class_Project.ViewModels;

namespace Class_Project.Controllers
{
    public class InstructorController : Controller
    {
        // moved data from FakeData service to SeedData database
        /*
        // inject FakeData service
        // moved hard-coded data from the constructor here to the constructor in the FakeData service
        IFakeData _fakedata;  // local instance
        public InstructorController(IFakeData theFakeDataService)  // need constructor to create the instance
        {
            _fakedata = theFakeDataService;
        }
        */

        // inject the Entity Framework database we created; inject the DbContext class in here
        private MyDataDbContext _dbContext;
        public InstructorController(MyDataDbContext dbContext)
        {
            _dbContext = dbContext;
            // change _fakedata.InstructorsList to _dbContext.Instructors.ToList()
        }

        // display a list of all the instructors
        public IActionResult Index(string lastNameSearched)
        {
            var instructors = from inst in _dbContext.Instructors
                              select inst;  // LINQ

            // narrow down the results
            if (lastNameSearched != null)
            {
                // filter for exact last name all spelled out
                //instructors = instructors.Where(x => x.LastName.ToUpper() == lastNameSearched.ToUpper());  // ToUpper so it's not case-sensitive
                // filter for a few letters, not full last name:
                instructors = instructors.Where(x => x.LastName.ToUpper().Contains(lastNameSearched.ToUpper()));
            }

            // ViewModel from ViewModels folder
            InstructorsFilterViewModel vm = new InstructorsFilterViewModel();
            vm.FilterVM = lastNameSearched;
            vm.InstructorsListVM = instructors.ToList();

            // displays all instructors if there's no filter query; other shows filtered results
            return View(vm);
        }

        public IActionResult ShowAll()
        {
            return RedirectToAction("Index", _dbContext.Instructors.ToList());  // doesn't show the same URL
        }

        public IActionResult DisplayAll()
        {
            return View("Index", _dbContext.Instructors.ToList());  // shows the same URL
        }

        // display the details of one instructor
        public IActionResult ShowDetails(int id)
        {
            // search database for the instructor
            Instructor? oneInstr = _dbContext.Instructors.FirstOrDefault(instr => instr.InstructorId == id);  // lambda expression
            // ? so null can be a result

            return View(oneInstr);  // return the result via a view
        }

        [HttpGet]  // responds to GET requests to display form
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
            // if ModelState is NOT valid, don't add, and return to Add view
            if (!ModelState.IsValid)
                return View();

            // if ModelState IS valid, add, and return to Index view
            _dbContext.Instructors.Add(instr);  // add the new instructor to the full list of instructors
            _dbContext.SaveChanges();  // must be called to save change to database
            return RedirectToAction("Index");
        }

        [HttpGet]  // responds to GET requests to display a pre-populated form
        public IActionResult Edit(int id)
        {
            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = _dbContext.Instructors.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            return View(foundInstr);
        }

        [HttpPost]  // this view will be shown only in response to a POST request, not a get request
        public IActionResult Edit(Instructor instrChanges)
        {
            // if ModelState is NOT valid, don't edit, and return to Edit view to display errors
            if (!ModelState.IsValid)
                return View(instrChanges);

            // if ModelState IS valid, save the edits, and return to Index view
            Instructor? foundInstr = _dbContext.Instructors.FirstOrDefault(instr => instr.InstructorId == instrChanges.InstructorId);

            if (foundInstr != null)
            {
                // put what's in the form into the database/list
                foundInstr.LastName = instrChanges.LastName;
                foundInstr.FirstName = instrChanges.FirstName;
                foundInstr.IsTenured = instrChanges.IsTenured;
                foundInstr.Position = instrChanges.Position;
                foundInstr.HireDate = instrChanges.HireDate;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // confirm the user wants to delete the instructor
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = _dbContext.Instructors.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            if (foundInstr != null)
                return View(foundInstr);
            else
                return NotFound();  // built-in action (displays HTTP Error 404)
        }

        // perform delete request
        [HttpPost, ActionName("Delete")]  // this line plus changing the action name fixes the problem of having two matching action names with matching parameters
        public IActionResult PerformDelete(int id)
        {
            // search the list we have; "?" allows for null if not found
            Instructor? foundInstr = _dbContext.Instructors.FirstOrDefault(instr => instr.InstructorId == id);  // or (instr => instr.InstructorId.Equals(id))

            // delete it
            _dbContext.Instructors.Remove(foundInstr);
            _dbContext.SaveChanges();

            // return user to Index view
            return RedirectToAction("Index");
        }
    }
}

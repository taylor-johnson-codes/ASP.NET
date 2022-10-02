// Controllers respond to a website user clicking on buttons and links.
// Controllers use .cs files; they are C# .NET classes that inherit from the following library

// Create a Controllers folder in the project
// Right click on folder, Add Controller (empty option)

using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    // A class is a controller class if at least one of these conditions are true:
    // - The class is suffixed with "Controller" (convention over configuration)
    // - The class inherits from a class whose name is suffixed with "Controller"
    // - The [Controller] attribute is applied to the class

    public class HomeController : Controller  // my HomeController class inherits from the built-in Controller class
    {
        // public methods are called "actions"
        // IActionResult lets your return different types of action results
        public IActionResult Index()
        {
            //return View();  // added by default in new controller, don't need now

            return Content("Hello from Index action of Home controller");
            // localhost:#### OR localhost:####/Home/Index
        }

        public IActionResult SecondAction()
        {
            return Content("Hello from Second action of Home controller");
            // localhost:####/Home/SecondAction
        }

        public IActionResult ThirdAction(int id)
        {
            return Content($"Hello from Third action (with required parameter) of Home controller, {id}^2={id*id}");
            // localhost:####/Home/ThirdAction/#
        }
    }
}

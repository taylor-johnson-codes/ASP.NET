using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    public class HomeController : Controller  // my HomeController class inherits from the built-in Controller class
    {
        // public methods are called "actions"
        public IActionResult Index()
        {
            //return View();  // added by default in new controller, don't need

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
            return Content($"Hello from Third action of Home controller, {id}^2={id*id}");
            // localhost:####/Home/ThirdAction/#
        }
    }
}

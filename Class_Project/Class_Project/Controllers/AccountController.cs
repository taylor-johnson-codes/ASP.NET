using Class_Project.Models;
using Class_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Class_Project.Controllers
{
    public class AccountController : Controller
    {
        // EF Core Identity needs to be installed with NuGet package and code needs to be added to Program.cs for it

        // inject services from Program.cs
        private SignInManager<User> _signInManager;  // null reference 
        private UserManager<User> _userManager;  // null reference 
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;  // populated reference
            _userManager = userManager;  // populated reference
        }

        // log in form
        public IActionResult Login()
        {
            // optional - if user is already authenticated
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated == true)
            {
                RedirectToAction("Index", "Instructor");
            }
            return View();  // login form
        }

        // perform login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userInput)  // Task<> for async; async since it might take a while
        {
            if (ModelState.IsValid)
            {
                // attempt to login
                var result = await _signInManager.PasswordSignInAsync(userInput.UserName, userInput.Password, 
                    userInput.RememberMe, false);  // false to not lockout on failure; await goes with async

                if (result.Succeeded)
                    return RedirectToAction("Index", "Instructor");
                else
                    ModelState.AddModelError("", "Login failed.");
            }

            return View(userInput);
        }

        // log out
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Instructor");  // redirect to any publicly accessible page
        }

        // register form 
        public IActionResult Register()
        {
            return View();
        }

        // perform registration
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userInput)
        {
            if (ModelState.IsValid)
            {
                // create the new user without the password
                User newUser = new User();
                newUser.FirstName= userInput.FirstName;
                newUser.LastName= userInput.LastName;
                newUser.UserName= userInput.UserName;
                newUser.Email= userInput.Email;
                newUser.PhoneNumber = userInput.PhoneNumber;

                // attempt to register with password
                var result = await _userManager.CreateAsync(newUser, userInput.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Instructor");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(userInput);
        }
    }
}

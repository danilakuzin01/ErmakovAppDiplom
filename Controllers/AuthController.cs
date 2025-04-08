namespace ErmakovAppDiplom.Controllers
{
    using ErmakovAppDiplom.Models;
    using ErmakovAppDiplom.Models.ViewModel;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    namespace IdentityAuth.Controllers
    {
        public class AuthController : Controller
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;

            public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Register() => View();

            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (!ModelState.IsValid) return View(model);

                var user = new User { 
                    UserName = model.Username, 
                    Email = model.Email, 
                    FirstName=model.FirtName, 
                    LastName=model.LastName, 
                    SecondName=model.SecondName,
                    IsActive = true
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            [HttpGet]
            public IActionResult Login() => View();

            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (!ModelState.IsValid) return View(model);

                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt");
                return View(model);
            }

            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
        }
    }
}

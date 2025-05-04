using ErmakovAppDiplom.Repositories.IRepositories;
using ErmakovAppDiplom.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = _userService.GetAll();
            return View(model);
        }
    }
}

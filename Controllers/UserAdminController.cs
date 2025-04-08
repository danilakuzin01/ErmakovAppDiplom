using ErmakovAppDiplom.Services;
using ErmakovAppDiplom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class UserAdminController : Controller
    {
        private IUserService _userService;

        public UserAdminController(IUserService userService)
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

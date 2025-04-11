using ErmakovAppDiplom.Repositories.IRepositories;
using ErmakovAppDiplom.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class UserAdminController : Controller
    {
        private IUserRepository _userService;

        public UserAdminController(IUserRepository userService)
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

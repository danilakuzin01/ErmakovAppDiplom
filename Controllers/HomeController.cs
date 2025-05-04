using System.Diagnostics;
using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, 
            IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Получаем текущего пользователя
            var user = await _userManager.GetUserAsync(User);

            ViewBag.UsersCount = _userRepository.GetAll().Count;
            ViewBag.AdminsCount = _userManager.GetUsersInRoleAsync("Admin").Result.Count;

            ViewBag.Tasks = _taskRepository.GetLastFive();

            if (user != null)
            {
                // Передаем FirstName в View
                ViewData["UserName"] = user.UserName;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

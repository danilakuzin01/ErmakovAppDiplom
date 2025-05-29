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
        private readonly UserManager<User> _userManager;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;

        public HomeController(UserManager<User> userManager, IUserRepository userRepository, 
            ITaskRepository taskRepository, IAdvertisementRepository advertisementRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _advertisementRepository = advertisementRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Получаем текущего пользователя
            var user = await _userManager.GetUserAsync(User);

            ViewBag.UsersCount = _userRepository.GetAll().Count;
            ViewBag.AdminsCount = _userManager.GetUsersInRoleAsync("Admin").Result.Count;
            ViewBag.Advertisements = _advertisementRepository.GetAll();
            ViewBag.SectionName = user.Section.Name;

            if (user.Section.Name.Equals("IT-отдел") || User.IsInRole("Admin"))
            {
                ViewBag.Tasks = _taskRepository.GetAllLastTen();
                ViewBag.InWorkTasks = _taskRepository.GetInProgress();
                ViewBag.WaitingTasks = _taskRepository.GetWaiting();
                ViewBag.CompletedTasks = _taskRepository.GetCompleted();
            }
            else
            {
                ViewBag.Tasks = _taskRepository.GetAllByUser(user);
                ViewBag.InWorkTasks = _taskRepository.GetInProgressByUser(user);
                ViewBag.WaitingTasks = _taskRepository.GetWaitingByUser(user);
                ViewBag.CompletedTasks = _taskRepository.GetCompletedByUser(user);
            }


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

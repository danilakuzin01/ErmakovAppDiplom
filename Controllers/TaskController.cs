using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ErmakovAppDiplom.Controllers
{
    public class TaskController : Controller
    {

        private readonly UserManager<User> _userManager;
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;

        public TaskController(UserManager<User> userManager, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Получаем текущего пользователя
            var user = await _userManager.GetUserAsync(User);
            User currentUser = _userRepository.GetById(user.Id);
            ViewBag.SectionName = currentUser.Section?.Name ?? null;
            ViewBag.Tasks = _taskRepository.GetAll();
            ViewBag.InWorkTasks = _taskRepository.GetInProgress();
            ViewBag.WaitingTasks = _taskRepository.GetWaiting();
            ViewBag.CompletedTasks = _taskRepository.GetCompleted();
            List<TaskModel> tasks = _taskRepository.GetAll();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult SetCompleted(long id)
        {
            _taskRepository.SetCompleated(id);
            
            return RedirectToAction("Index", "Home"); // или нужная страница
        }
        
        [HttpPost]
        public IActionResult SetInWork(long id)
        {
            _taskRepository.SetInWork(id);
            
            return RedirectToAction("Index", "Home"); // или нужная страница
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var user = await _userManager.GetUserAsync(User);

            var task = new TaskModel
            {
                Title = model.Title,
                Description = model.Description,
                DeadLine = model.DeadLine = model.DeadLine.ToUniversalTime(),
                Difficult = model.Difficult,
                Status = "Ожидает",
                User = user
            };

            _taskRepository.Create(task);

            return RedirectToAction("Index", "Home"); // или другой результат
        }
    }
}

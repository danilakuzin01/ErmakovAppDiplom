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

        public TaskController(ITaskRepository taskRepository, UserManager<User> userManager)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
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

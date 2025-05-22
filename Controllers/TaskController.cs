using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Controllers
{
    public class TaskController : Controller
    {

        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public IActionResult SetCompleted(long id)
        {
            _taskRepository.SetCompleated(id);
            
            return RedirectToAction("Index", "Home"); // или нужная страница
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = new TaskModel
            {
                Title = model.Title,
                Description = model.Description,
                DeadLine = model.DeadLine = model.DeadLine.ToUniversalTime(),
                Difficult = model.Difficult,
                Status = "Ожидает"
            };

            _taskRepository.Create(task);

            return RedirectToAction("Index", "Home"); // или другой результат
        }
    }
}

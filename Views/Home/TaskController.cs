using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Views.Home
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
    }
}

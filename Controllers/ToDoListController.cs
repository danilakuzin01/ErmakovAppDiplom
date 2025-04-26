using ErmakovAppDiplom.Models;
using Microsoft.AspNetCore.Mvc;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;

namespace ErmakovAppDiplom.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {

        private IToDoListRepository _todolistService;

        public ToDoListController(IToDoListRepository toDoListService)
        {
            _todolistService = toDoListService;
        }

        public IActionResult Index()
        {
            List<ToDoList> model = _todolistService.GetAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ToDoList toDoList)
        {
            _todolistService.Create(toDoList);

            // Перенаправляем на страницу с задачами (перезагружаем список задач)
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ToDoList model = _todolistService.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList toDoList)
        {
            _todolistService.Update(toDoList);
            return RedirectToAction("Index");
        }

    }
}

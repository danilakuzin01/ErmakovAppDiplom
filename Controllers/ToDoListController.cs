using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class ToDoListController : Controller
    {

        private IToDoListService _todolistService;

        public ToDoListController(IToDoListService toDoListService)
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

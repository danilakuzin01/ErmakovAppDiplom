using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Services.Interfaces
{
    public interface IToDoListService
    {
        List<ToDoList> GetAll();
        ToDoList GetById(int id);
        List<ToDoList> GetAllByUser(User user);
        void Create(ToDoList toDoList);
        void Update(ToDoList toDoList);
        void Delete(int id);
    }
}

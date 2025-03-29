using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IToDoRepository
    {
        List<ToDoList> GetAll();
        void Create(ToDoList toDoList);
        void Update(ToDoList toDoList);
        void Delete(int id);
    }
}

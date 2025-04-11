using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Services
{
    public class ToDoListRepository : IToDoListRepository
    {
        private AppDbContext _context;

        public ToDoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(ToDoList toDoList)
        {
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ToDoList toDoList = _context.ToDoLists.FirstOrDefault(x => x.Id == id);
            _context.ToDoLists.Remove(toDoList);
            _context.SaveChanges();
        }

        public List<ToDoList> GetAll()
        {
            return _context.ToDoLists.Include(t => t.User).ToList();
        }

        public List<ToDoList> GetAllByUser(User user)
        {
            return _context.ToDoLists.Include(t => t.User).Where(t => t.User.Equals(user)).ToList();
        }

        public ToDoList GetById(int id)
        {
            return _context.ToDoLists.Include(t => t.User).FirstOrDefault(t => t.Id.Equals(id));
        }

        public void Update(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);
            _context.SaveChanges();
        }
    }
}

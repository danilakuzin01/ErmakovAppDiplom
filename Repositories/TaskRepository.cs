using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskModel> GetAll()
        {
           return _context.Tasks
                .Include(t => t.User)
                .ToList();
        }

        public List<TaskModel> GetAllByUser(User user)
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.User.Id == user.Id)
                .ToList();
        }

        public List<TaskModel> GetCompleted()
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.Status.Equals("Выполнено"))
                .ToList();
        }

        public List<TaskModel> GetWaiting()
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.Status.Equals("Ожидает"))
                .ToList();
        }
        public List<TaskModel> GetInProgress()
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.Status.Equals("В процессе"))
                .ToList();
        }

        public List<TaskModel> GetWaitingByUser(User user)
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.User.Id == user.Id)
                .Where(t => t.Status.Equals("Ожидает"))
                .ToList();
        }

        public List<TaskModel> GetInProgressByUser(User user)
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.User.Id == user.Id)
                .Where(t => t.Status.Equals("В процессе"))
                .ToList();
        }

        public List<TaskModel> GetCompletedByUser(User user)
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.User.Id == user.Id)
                .Where(t => t.Status.Equals("Выполнено"))
                .ToList();
        }

        public void SetCompleated(long id)
        {
            TaskModel task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            task.Status = "Выполнено";
            _context.Tasks.Update(task);
            _context.SaveChanges();
        } 
        
        public void SetInWork(long id)
        {
            TaskModel task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            task.Status = "В работе";
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Create(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}

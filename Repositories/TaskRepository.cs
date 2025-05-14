using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

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
           return _context.Tasks.ToList();
        }

        public List<TaskModel> GetCompleted()
        {
            return _context.Tasks.Where(t => t.Status.Equals("Выполнено")).ToList();
        }

        public List<TaskModel> GetWaiting()
        {
            return _context.Tasks.Where(t => t.Status.Equals("Ожидает")).ToList();
        }
        public List<TaskModel> GetInProgress()
        {
            return _context.Tasks.Where(t => t.Status.Equals("В процессе")).ToList();
        }

        public List<TaskModel> GetLastFive()
        {
            return _context.Tasks.ToList();
        }

        public void SetCompleated(long id)
        {
            TaskModel task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            task.Status = "Выполнено";
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}

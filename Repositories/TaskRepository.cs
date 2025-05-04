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

        public List<TaskModel> GetCompleated()
        {
            return _context.Tasks.Where(t => t.Status.Equals("Выполнено")).ToList();
        }

        public List<TaskModel> GetInProgress()
        {
            return _context.Tasks.Where(t => t.Status.Equals("В процессе")).ToList();
        }

        public List<TaskModel> GetLastFive()
        {
            return _context.Tasks.ToList();
        }
    }
}

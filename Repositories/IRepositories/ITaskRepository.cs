using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAll();
        List<TaskModel> GetAllByUser(User user);
        List<TaskModel> GetWaiting();
        List<TaskModel> GetInProgress();
        List<TaskModel> GetCompleted();
        List<TaskModel> GetWaitingByUser(User user);
        List<TaskModel> GetInProgressByUser(User user);
        List<TaskModel> GetCompletedByUser(User user);
        void SetInWork(long id);
        void SetCompleated(long id);
        void Create(TaskModel task);
        void Update(TaskModel task);
        void Delete(long id);
    }
}

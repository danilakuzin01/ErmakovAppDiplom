using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAll();
        List<TaskModel> GetLastFive();
        List<TaskModel> GetInProgress();
        List<TaskModel> GetCompleted();
        void SetCompleated(long id);
    }
}

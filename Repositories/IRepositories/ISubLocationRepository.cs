using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface ISubLocationRepository
    {
        List<SubLocation> GetAll();
        SubLocation GetById(long id);
    }
}

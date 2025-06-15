using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        Location GetById(int id);
        void Create(Location location);
        void Update(Location location);
        void Delete(int id);
    }
}

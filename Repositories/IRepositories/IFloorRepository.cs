using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IFloorRepository
    {
        List<Floor> GetAll();
        Floor GetById(long id);
        Floor Create(Floor floor);
        Floor Update(Floor floor);
        void Delete (long id);
    }
}

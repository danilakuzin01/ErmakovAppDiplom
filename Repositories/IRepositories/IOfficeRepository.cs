using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IOfficeRepository
    {
        List<Office> GetAll();
        Office GetById(int id);
        void Create(Office office);
        void Update(Office office);
        void Delete(Office office);
    }
}

using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IAdvertisementRepository
    {
        List<Advertisement> GetAll();
        void Create(Advertisement advertisement);
        void Update(Advertisement advertisement);
        void Delete(long id);
    }
}

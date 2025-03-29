using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IStaffRepository
    {
        List<Staff> GetAll();
        Staff GetById(int id);
        void Create(Staff staff);
        void Update(Staff staff);
        void Delete(int id);
    }
}

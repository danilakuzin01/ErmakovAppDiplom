using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetByUsername(string userName);
        User GetById(string  id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);

        List<User> GetAllByFilter(UserFilterViewModel userFilter);
    }
}

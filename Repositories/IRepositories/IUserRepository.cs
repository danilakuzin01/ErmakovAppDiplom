using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetByUsername(string userName);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}

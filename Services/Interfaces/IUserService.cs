using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetByUsername(string userName);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}

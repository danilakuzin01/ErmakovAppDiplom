using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Services.Interfaces;

namespace ErmakovAppDiplom.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

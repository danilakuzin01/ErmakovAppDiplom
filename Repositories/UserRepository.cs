using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            var users = _userManager.Users
                .Include(u => u.Items)
                .Include(u => u.Post)
                .Include(u => u.Section)
                .Include(u => u.Sublocation)
                    .ThenInclude(s => s.Location)
                .ToList();

            //foreach (var user in users)
            //{
            //    _context.Entry(user).Collection(u => u.Items).Load();
            //    _context.Entry(user).Reference(u => u.Sublocation).Load();
            //    _context.Entry(user).Reference(u => u.Post).Load();
            //    _context.Entry(user).Reference(u => u.Section).Load();
            //    _context.Entry(user.Sublocation).Reference(sl => sl.Location).Load(); // если нужно
            //}

            return users;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllByFilter(UserFilterViewModel userFilter)
        {
            IQueryable<User> users = _context.Users
                .Include(u => u.Items)
                .Include(u => u.Post)
                .Include(u => u.Section);

            if (!string.IsNullOrEmpty(userFilter.Search))
            {
                users = users
                    .Where(u => u.FirstName.ToLower().Contains(userFilter.Search.ToLower())
                || u.LastName.ToLower().Contains(userFilter.Search.ToLower())
                || u.Email.ToLower().Contains(userFilter.Search.ToLower())
                || u.Post.Name.ToLower().Contains(userFilter.Search.ToLower())
                );
            }
            
            // фильтр по секциям
            if (userFilter.SectionId != null && userFilter.SectionId != 0)
            {
                users = users.Where(u => u.SectionId.Equals(userFilter.SectionId));
            }

            // фильтр по роли
            if (userFilter.RoleId != null && userFilter.RoleId != "all")
            {
                users = (from u in users
                         join ur in _context.UserRoles on u.Id equals ur.UserId
                         join r in _context.Roles on ur.RoleId equals r.Id
                         where r.Name == userFilter.RoleId
                         select u);
            }
            return users.ToList();
        }

        public User GetById(string id)
        {
            return _context.Users
                .Include(u => u.Post)
                .Include(u => u.Section)
                .FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}

using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private AppDbContext _context;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Staff staff)
        {
            _context.Staff.Add(staff);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Staff? staff = _context.Staff.FirstOrDefault(x => x.Id == id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                _context.SaveChanges();
            }
        }

        public List<Staff> GetAll()
        {
            return _context.Staff.ToList();
        }

        public Staff GetById(int id)
        {
            return _context.Staff.FirstOrDefault(s => s.Id.Equals(id));
        }

        public void Update(Staff staff)
        {
            _context.Staff.Update(staff);
            _context.SaveChanges();
        }
    }
}

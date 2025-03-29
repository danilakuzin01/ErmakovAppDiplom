using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private AppDbContext _context;

        public OfficeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Office office)
        {
            _context.Offices.Add(office);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Office? office = _context.Offices.FirstOrDefault(o => o.Id == id);
            if (office != null)
            {
                _context.Offices.Remove(office);
                _context.SaveChanges();
            }
        }

        public List<Office> GetAll()
        {
            return _context.Offices.ToList();
        }

        public Office GetById(int id)
        {
            return _context.Offices.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Office office)
        {
            _context.Offices.Update(office);
            _context.SaveChanges();
        }
    }
}

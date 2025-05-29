using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Repositories
{
    public class SubLocationRepository : ISubLocationRepository
    {
        private AppDbContext _context;

        public SubLocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(SubLocation location)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            SubLocation subLocation = _context.Sublocations.FirstOrDefault(x => x.Id == id);
            _context.Sublocations.Remove(subLocation);
            _context.SaveChanges();
        }

        public List<SubLocation> GetAll()
        {
            return _context.Sublocations.Include(x => x.Location).Include(x => x.Floor).ToList();
        }

        public SubLocation GetById(long id)
        {
            return _context.Sublocations.FirstOrDefault(s => s.Id == id);
        }

        public void Update(SubLocation subLocation)
        {
            _context.Sublocations.Update(subLocation);
            _context.SaveChanges();
        }
    }
}

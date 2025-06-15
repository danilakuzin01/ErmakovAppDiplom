using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Location location)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return _context.Locations.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}

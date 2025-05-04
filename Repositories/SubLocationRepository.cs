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

        public List<SubLocation> GetAll()
        {
            return _context.Sublocations.Include(x => x.Floor).ToList();
        }
    }
}

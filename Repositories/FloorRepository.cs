using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private AppDbContext _context;

        public FloorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Floor Create(Floor floor)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Floor> GetAll()
        {
            return _context.Floors.ToList();
        }

        public Floor GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Floor Update(Floor floor)
        {
            throw new NotImplementedException();
        }
    }
}

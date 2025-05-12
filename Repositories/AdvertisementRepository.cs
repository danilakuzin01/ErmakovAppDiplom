using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private AppDbContext _context;

        public AdvertisementRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Advertisement> GetAll()
        {
            return _context.Advertisements
                .Include(a => a.User)
                .OrderBy(a => a.PublishDate).ToList();
        }

        public void Update(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
    }
}

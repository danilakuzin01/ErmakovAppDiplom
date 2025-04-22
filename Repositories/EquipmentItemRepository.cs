using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom.Repositories
{
    public class EquipmentItemRepository : IEquipmentItemRepository
    {
        private AppDbContext _context;

        public EquipmentItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(EquipmentItem staff)
        {
            _context.EquipmentItems.Add(staff);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            EquipmentItem? staff = _context.EquipmentItems.FirstOrDefault(x => x.Id == id);
            if (staff != null)
            {
                _context.EquipmentItems.Remove(staff);
                _context.SaveChanges();
            }
        }

        public List<EquipmentItem> GetAll()
        {
            return _context.EquipmentItems.Include(x => x.Category).ToList();
        }

        public EquipmentItem GetById(int id)
        {
            return _context.EquipmentItems.Include(x => x.Category).FirstOrDefault(s => s.Id.Equals(id));
        }

        public void Update(EquipmentItem staff)
        {
            _context.EquipmentItems.Update(staff);
            _context.SaveChanges();
        }
    }
}

using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;
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

        public void Create(EquipmentItem item)
        {
            _context.EquipmentItems.Add(item);
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
            return _context.EquipmentItems
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.SubLocation)
                        .ThenInclude(y => y.Location)
                .ToList();
        }

        public List<EquipmentItem> GetAllByFilter(EquipmentItemFilterViewModel equipmentFilter)
        {
            IQueryable<EquipmentItem> equipments = _context.EquipmentItems
                .Include(e => e.Category)
                .Include(e => e.SubLocation)
                    .ThenInclude(y => y.Location);
            if (!string.IsNullOrEmpty(equipmentFilter.Search))
            {
                equipments = equipments.Where(e => e.Name.ToLower().Contains(equipmentFilter.Search.ToLower())
                    || e.Model.ToLower().Contains(equipmentFilter.Search.ToLower())
                    || e.InventoryNumber.ToLower().Contains(equipmentFilter.Search.ToLower())
                    );
            }

            if (equipmentFilter.FilterCategoryId != 0)
            {
                equipments = equipments.Where(e => e.Category.Id == equipmentFilter.FilterCategoryId);
            }

            if (!equipmentFilter.FilterStatus.Equals("all"))
            {
                equipments = equipments.Where(e => e.Status.Equals(equipmentFilter.FilterStatus));
            }

            return equipments.ToList();
        }

        public EquipmentItem GetById(int id)
        {
            return _context.EquipmentItems
                .Include(x => x.Category)
                .Include(x => x.SubLocation)
                .Include(x => x.User)
                .FirstOrDefault(s => s.Id.Equals(id));
        }

        public void Update(EquipmentItem item)
        {
            _context.EquipmentItems.Update(item);
            _context.SaveChanges();
        }
    }
}

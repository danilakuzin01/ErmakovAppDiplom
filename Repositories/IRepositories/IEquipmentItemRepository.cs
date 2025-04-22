using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IEquipmentItemRepository
    {
        List<EquipmentItem> GetAll();
        EquipmentItem GetById(int id);
        void Create(EquipmentItem staff);
        void Update(EquipmentItem staff);
        void Delete(int id);
    }
}

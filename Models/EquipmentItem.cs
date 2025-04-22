using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using ErmakovAppDiplom;

namespace ErmakovAppDiplom.Models
{
    public class EquipmentItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; } // Внешний ключ
        public Category Category { get; set; } // Навигационное свойство

        public List<EquipmentItemAttribute> Attributes { get; set; }
    }
}

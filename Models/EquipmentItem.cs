using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using ErmakovAppDiplom;

namespace ErmakovAppDiplom.Models
{
    public class EquipmentItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }

        public int CategoryId { get; set; } // Внешний ключ
        public Category? Category { get; set; } // Навигационное свойство

        public string? Status { get; set; }

        public string? InventoryNumber { get; set; }

        //public Location? Location { get; set; }
        public SubLocation SubLocation { get; set; }
        public User User { get; set; }

        public List<EquipmentItemAttribute> Attributes { get; set; }
    }
}

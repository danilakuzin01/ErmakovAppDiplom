using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using ErmakovAppDiplom;

namespace ErmakovAppDiplom.Models
{
    public class EquipmentItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public int CategoryId { get; set; } // Внешний ключ
        public Category Category { get; set; } // Навигационное свойство
        public string InventoryNumber { get; set; }
        public User? User { get; set; }
        public string Status { get; set; }

        public SubLocation? SubLocation { get; set; }


        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}

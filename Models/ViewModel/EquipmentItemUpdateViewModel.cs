namespace ErmakovAppDiplom.Models.ViewModel
{
    public class EquipmentItemUpdateViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string InventoryNumber { get; set; }
        public string Status { get; set; }
        public long? SubLocationId { get; set; }
        public string? UserId { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}

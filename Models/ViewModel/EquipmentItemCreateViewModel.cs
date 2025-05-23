namespace ErmakovAppDiplom.Models.ViewModel
{
    public class EquipmentItemCreateViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string InventoryNumber { get; set; }
        public string Status { get; set; }
        public long SubLocationId { get; set; }
        public string UserId { get; set; }
    }
}

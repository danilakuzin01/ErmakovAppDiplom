namespace ErmakovAppDiplom.Models
{
    public class EquipmentItemAttribute
    {
        public int Id { get; set; }
        public EquipmentItem EquipmentItem { get; set; }
        public Attribute Attribute { get; set; }

        public string Value { get; set; }
    }
}
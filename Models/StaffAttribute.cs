namespace ErmakovAppDiplom.Models
{
    public class StaffAttribute
    {
        public int Id { get; set; }
        public Staff Staff { get; set; }
        public Attribute Attribute { get; set; }

        public string Value { get; set; }
    }
}

namespace ErmakovAppDiplom.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StaffAttribute> Attributes { get; set; }
    }
}

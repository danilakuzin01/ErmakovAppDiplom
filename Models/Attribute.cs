namespace ErmakovAppDiplom.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
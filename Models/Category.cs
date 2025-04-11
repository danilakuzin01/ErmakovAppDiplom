namespace ErmakovAppDiplom.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; } // Коллекция атрибутов
    }
}

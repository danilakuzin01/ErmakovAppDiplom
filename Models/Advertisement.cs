namespace ErmakovAppDiplom.Models
{
    public class Advertisement
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

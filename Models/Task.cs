namespace ErmakovAppDiplom.Models
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public string Difficult { get; set; }
        public string Status { get; set; }
    }
}

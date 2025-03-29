namespace ErmakovAppDiplom.Models
{
    public class BoardNote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public string Status { get; set; }

        // Внешние ключи
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public string ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}

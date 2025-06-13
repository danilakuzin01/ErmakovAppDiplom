namespace ErmakovAppDiplom.Models.ViewModel
{
    public class UserUpdateViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondName { get; set; }
        public int PostId { get; set; }
        public int SublocationId { get; set; }
        public int SectionId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}

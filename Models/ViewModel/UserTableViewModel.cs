namespace ErmakovAppDiplom.Models.ViewModel
{
    public class UserTableViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string? PostName { get; set; }
        public string? SectionName { get; set; }
        public string? LocationName { get; set; }
        public string? SublocationName { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public List<string> Roles { get; set; }
    }
}

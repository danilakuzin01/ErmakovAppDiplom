
using Microsoft.AspNetCore.Identity;

namespace ErmakovAppDiplom.Models
{
    public class User: IdentityUser
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public bool IsActive { get; set; }
    }
}

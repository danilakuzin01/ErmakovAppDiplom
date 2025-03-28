﻿
using Microsoft.AspNetCore.Identity;

namespace ErmakovAppDiplom.Models
{
    public class User: IdentityUser
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public bool IsActive { get; set; }

        // Навигационные свойства
        public ICollection<BoardNote> BoardNotesAsOwner { get; set; } = new List<BoardNote>();
        public ICollection<BoardNote> BoardNotesAsReceiver { get; set; } = new List<BoardNote>();
        public List<ToDoList> ToDoList { get; set; }
    }
}

﻿
using Microsoft.AspNetCore.Identity;

namespace ErmakovAppDiplom.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondName { get; set; }
        public Post? Post { get; set; }
        public long PostId { get; set; }
        public SubLocation? Sublocation { get; set; }
        public long SublocationId { get; set; }
        public Section? Section { get; set; }
        public long SectionId { get; set; }
        public bool IsActive { get; set; }

        // Навигационные свойства
        public List<EquipmentItem> Items { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}

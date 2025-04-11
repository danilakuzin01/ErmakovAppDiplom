using System.ComponentModel.DataAnnotations;

namespace ErmakovAppDiplom.Models.ViewModel
{
    public class AttributeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Категория обязательна")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; } = new();
    }
}

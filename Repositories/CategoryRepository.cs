using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id.Equals(id));
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}

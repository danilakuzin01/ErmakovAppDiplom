using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Section section)
        {
            _context.Sections.Add(section);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Section? section = _context.Sections.FirstOrDefault(s => s.Id == id);
            if (section != null)
            {
                _context.Sections.Remove(section);
                _context.SaveChanges();
            }
        }

        public List<Section> GetAll()
        {
            return _context.Sections.ToList();
        }

        public Section GetById(int id)
        {
            return _context.Sections.FirstOrDefault(s => s.Id.Equals(id));
        }

        public void Update(Section section)
        {
            _context.Sections.Update(section);
            _context.SaveChanges();
        }
    }
}

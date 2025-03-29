using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private AppDbContext _context;

        public AttributeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Models.Attribute attribute)
        {
            _context.Attributes.Add(attribute);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            Models.Attribute? attribute = _context.Attributes.FirstOrDefault(a => a.Id == id);
            if (attribute != null)
            {
                _context.Attributes.Remove(attribute);
                _context.SaveChanges();
            }
        }

        public List<Models.Attribute> GetAll()
        {
            return _context.Attributes.ToList();
        }

        public Models.Attribute GetById(int id)
        {
            return _context.Attributes.FirstOrDefault(a => a.Id.Equals(id));
        }

        public void Update(Models.Attribute attribute)
        {
            _context.Attributes.Update(attribute);
            _context.SaveChanges();
        }
    }
}

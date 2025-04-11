using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Attribute = ErmakovAppDiplom.Models.Attribute;

namespace ErmakovAppDiplom.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private AppDbContext _context;

        public AttributeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Attribute attribute)
        {
            _context.Attributes.Add(attribute);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            Attribute? attribute = _context.Attributes.FirstOrDefault(a => a.Id == id);
            if (attribute != null)
            {
                _context.Attributes.Remove(attribute);
                _context.SaveChanges();
            }
        }

        public List<Attribute> GetAll()
        {
            return _context.Attributes.Include(c => c.Category).Include(c => c.Category).ToList();
        }

        public Attribute GetById(int id)
        {
            return _context.Attributes.Include(c => c.Category).FirstOrDefault(a => a.Id.Equals(id));
        }

        public void Update(Attribute attribute)
        {
            _context.Attributes.Update(attribute);
            _context.SaveChanges();
        }
    }
}

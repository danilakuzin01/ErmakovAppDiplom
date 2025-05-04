using ErmakovAppDiplom.Models;

using Attribute = ErmakovAppDiplom.Models.Attribute;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IAttributeRepository
    {
        List<Attribute> GetAll();
        Attribute GetById(int id);

        void Create(Attribute attribute);
        void Update(Attribute attribute);
        void Delete(int id);
    }
}

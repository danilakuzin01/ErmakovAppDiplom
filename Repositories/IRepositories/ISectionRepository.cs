using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface ISectionRepository
    {
        List<Section> GetAll();
        Section GetById(int id);
        void Create(Section section);
        void Update(Section section);
        void Delete(int id);
    }
}

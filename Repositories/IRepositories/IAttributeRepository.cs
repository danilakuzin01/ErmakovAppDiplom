namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IAttributeRepository
    {
        List<Models.Attribute> GetAll();
        Models.Attribute GetById(int id);

        void Create(Models.Attribute attribute);
        void Update(Models.Attribute attribute);
        void Delete(int id);
    }
}

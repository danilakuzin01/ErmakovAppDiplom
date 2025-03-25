using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);
        void Create(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}

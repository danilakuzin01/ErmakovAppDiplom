using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Post? post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id.Equals(id));
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}

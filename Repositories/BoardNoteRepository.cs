using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories.IRepositories;

namespace ErmakovAppDiplom.Repositories
{
    public class BoardNoteRepository : IBoardNoteRepository
    {
        private AppDbContext _context;

        public BoardNoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(BoardNote boardNote)
        {
            _context.BoardNotes.Add(boardNote);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            BoardNote? note = _context.BoardNotes.FirstOrDefault(b => b.Id == id);
            if (note != null)
            {
                _context.BoardNotes.Remove(note);
                _context.SaveChanges();
            }
        }

        public List<BoardNote> GetAll()
        {
            return _context.BoardNotes.ToList();
        }

        public BoardNote GetById(int id)
        {
            return _context.BoardNotes.FirstOrDefault(b => b.Id.Equals(id));
        }

        public void Update(BoardNote boardNote)
        {
            _context.BoardNotes.Update(boardNote);
        }
    }
}

using ErmakovAppDiplom.Models;

namespace ErmakovAppDiplom.Repositories.IRepositories
{
    public interface IBoardNoteRepository
    {
        List<BoardNote> GetAll();
        BoardNote GetById(int id);
        void Create(BoardNote boardNote);
        void Update(BoardNote boardNote);
        void Delete(BoardNote boardNote);
    }
}

using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Contracts
{
    public interface IUnitOfWork
    {
        IBooksRepository BooksRepository { get; }
        IBaseRepository<Author> AuthorsRepository { get; }
        IBaseRepository<T> GetBaseRepo<T>() where T : Entity;

        void SaveAll();
    }
}
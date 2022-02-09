using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.Ef
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EfContext _context = new();
        public IBooksRepository BooksRepository => new EfBookRepository(_context);

        public IBaseRepository<Author> AuthorsRepository => GetBaseRepo<Author>();

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepository<T> GetBaseRepo<T>() where T : Entity
        {
            return new EfBaseRepository<T>(_context);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
}

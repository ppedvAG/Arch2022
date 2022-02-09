using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.Ef
{
    public class EfBookRepository : EfBaseRepository<Book>, IBooksRepository
    {
        public EfBookRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Book> GetBooksCreatedByAdmin()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _context.Books.Where(x => x.Created == DateTime.MinValue);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}

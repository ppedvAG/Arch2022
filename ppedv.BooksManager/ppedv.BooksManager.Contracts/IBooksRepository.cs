using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Contracts
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetBooksCreatedByAdmin();
    }
}
using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Logic
{
    public class BooksManagerService
    {
        public BooksManagerService(IRepository repo)
        {
            Repository = repo;
        }

        public IRepository Repository { get; }

        public Publisher? GetPublisherWithMostExpensivesBooks()
        {
            var result = Repository.Query<Publisher>()
                                   .OrderByDescending(x => x.Books.Sum(b => b. Price))
                                   .FirstOrDefault();

            return result;
        }
    }
}
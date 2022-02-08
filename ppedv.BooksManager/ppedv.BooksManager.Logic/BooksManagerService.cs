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
            return Repository.GetAll<Book>().GroupBy(x => x.Publisher)
                                            .OrderByDescending(x => x.Sum(b => b.Price))
                                            .FirstOrDefault()?.Key;
        }
    }
}
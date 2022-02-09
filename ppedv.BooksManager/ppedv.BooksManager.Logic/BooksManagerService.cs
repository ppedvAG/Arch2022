using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Logic
{
    public class BooksManagerService
    {
        public BooksManagerService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public IUnitOfWork UnitOfWork { get; }

        public Publisher? GetPublisherWithMostExpensivesBooks()
        {
            var result = UnitOfWork.GetBaseRepo<Publisher>().Query()
                                   .OrderByDescending(x => x.Books.Sum(b => b. Price))
                                   .FirstOrDefault();

            return result;
        }
    }
}
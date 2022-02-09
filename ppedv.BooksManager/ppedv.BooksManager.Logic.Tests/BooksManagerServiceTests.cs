using Moq;
using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;
using System.Linq;
using Xunit;

namespace ppedv.BooksManager.Logic.Tests
{
    public class BooksManagerServiceTests
    {
        [Fact]
        public void GetPublisherWithMostExpensivesBooks_No_books_in_DB_results_null()
        {
            var pubRepoMock = new Mock<IBaseRepository<Publisher>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetBaseRepo<Publisher>()).Returns(pubRepoMock.Object);

            var bms = new BooksManagerService(uowMock.Object);

            var result = bms.GetPublisherWithMostExpensivesBooks();

            Assert.Null(result);
        }

        [Fact]
        public void GetPublisherWithMostExpensivesBooks_2_books_one_is_more_expensive_results_in_publisher_1()
        {
            var pubRepoMock = new Mock<IBaseRepository<Publisher>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetBaseRepo<Publisher>()).Returns(pubRepoMock.Object);

            pubRepoMock.Setup(x => x.Query()).Returns(() =>
            {
                var p1 = new Publisher() { Name = "P1" };
                var b1 = new Book() { Price = 70m, Publisher = p1 };
                var b11 = new Book() { Price = 70m, Publisher = p1 };
                var b111 = new Book() { Price = 70m, Publisher = null };
                p1.Books.Add(b1);
                p1.Books.Add(b11);
                p1.Books.Add(b111);

                var p2 = new Publisher() { Name = "P2" };
                var b2 = new Book() { Price = 20m, Publisher = p2 };
                var b22 = new Book() { Price = 80m, Publisher = p2 };
                p2.Books.Add(b2);
                p2.Books.Add(b22);

                return new[] { p1, p2 }.AsQueryable();
            });
            var bms = new BooksManagerService(uowMock.Object);

            var result = bms.GetPublisherWithMostExpensivesBooks();

            Assert.Equal("P1", result?.Name);

        }
    }
}
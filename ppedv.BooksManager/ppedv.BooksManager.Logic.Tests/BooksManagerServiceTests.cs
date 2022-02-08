using Moq;
using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Model;
using Xunit;

namespace ppedv.BooksManager.Logic.Tests
{
    public class BooksManagerServiceTests
    {
        [Fact]
        public void GetPublisherWithMostExpensivesBooks_No_books_in_DB_results_null()
        {
            var mock = new Mock<IRepository>();
            var bms = new BooksManagerService(mock.Object);

            var result = bms.GetPublisherWithMostExpensivesBooks();

            Assert.Null(result);
        }

        [Fact]
        public void GetPublisherWithMostExpensivesBooks_2_books_one_is_more_expensive_results_in_publisher_1()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Book>()).Returns(() =>
            {
                var p1 = new Publisher() { Name = "P1" };
                var b1 = new Book() { Price = 70m, Publisher = p1 };
                var b11 = new Book() { Price = 70m, Publisher = p1 };
                //p1.Books.Add(b1);

                var p2 = new Publisher() { Name = "P2" };
                var b2 = new Book() { Price = 20m, Publisher = p2 };
                var b22 = new Book() { Price = 80m, Publisher = p2 };
                //p2.Books.Add(b2);
                return new[] { b1, b2, b11, b22 };
            });
            var bms = new BooksManagerService(mock.Object);

            var result = bms.GetPublisherWithMostExpensivesBooks();

            Assert.Equal("P1", result?.Name);

        }
    }
}
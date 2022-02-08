using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.BooksManager.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace ppedv.BooksManager.Data.Ef.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }


        [Fact]
        public void Can_add_and_read_a_Book_with_associated_data()
        {

            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var book = fix.Create<Book>();

            using (var con = new EfContext())
            {
                con.Add(book);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loadedBook = con.Books?.Find(book.Id);

                //Assert.Equal(book.Title, loadedBook.Title);
                //loadedBook.Title.Should().Be(book.Title);
                loadedBook.Should().BeEquivalentTo(book, c => c.IgnoringCyclicReferences());
            }

        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}
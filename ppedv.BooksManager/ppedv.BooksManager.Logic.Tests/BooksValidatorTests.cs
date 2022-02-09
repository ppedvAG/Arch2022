using ppedv.BooksManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.BooksManager.Logic.Tests
{

    public class BooksValidatorTests
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(-0.1, false)]
        [InlineData(0.1, true)]
        [InlineData(1, true)]
        public void BooksValidator_Price(decimal p, bool exp)
        {
            var b = new Book() { Price = p, Title = "AAA", SubTitle = "BBB", ISBN = "978-3-446-45509-2" };
            var vali = new BooksValidator();

            var result = vali.Validate(b);

            Assert.Equal(exp, result.IsValid);
        }
    }
}

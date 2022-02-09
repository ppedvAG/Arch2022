using FluentValidation;
using ppedv.BooksManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.BooksManager.Logic
{
    public class BooksValidator : AbstractValidator<Book>
    {
        public BooksValidator()
        {
            RuleFor(x => x.ISBN).Cascade(CascadeMode.Stop)
                                .NotEmpty()
                                .MinimumLength(9);
                                //.Matches(@"^\d{9}[\d|X]$").WithSeverity(Severity.Warning);

            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().WithMessage("Kein Titel, Kein Buch!");
            RuleFor(x => x.SubTitle).NotEmpty().WithSeverity(Severity.Warning);

        }
    }
}

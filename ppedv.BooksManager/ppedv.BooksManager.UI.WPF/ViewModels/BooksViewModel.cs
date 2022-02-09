using ppedv.BooksManager.Logic;
using ppedv.BooksManager.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ppedv.BooksManager.UI.WPF.ViewModels
{

    public class BooksViewModel : ViewModelBase
    {
        BooksManagerService _bms = new BooksManagerService(new Data.Ef.EfUnitOfWork());

        public List<Book> Books { get; set; }

        public Book? SelectedBook { get; set; }

        public ICommand SaveCommand { get; set; }

        public DateTime PublishedDate
        {
            get => SelectedBook != null ? SelectedBook.Published : DateTime.MinValue;
            set
            {
                if (SelectedBook != null)
                    SelectedBook.Published = value;
            }
        }

        //private Book? selectedBook;
        //public Book? SelectedBook
        //{
        //    get => selectedBook; set
        //    {
        //        selectedBook = value;
        //        OnThisPropertyChanged();
        //        OnPropertyChanged(nameof(PublishedYearInfo));
        //    }
        //}

        public string PublishedYearInfo
        {
            get
            {
                if (SelectedBook == null)
                    return "---";
                else
                    return $"Vor {DateTime.Now.Year - PublishedDate.Year} Jahren";
            }
        }

        public BooksViewModel()
        {
            Books = new List<Book>(_bms.UnitOfWork.BooksRepository.Query());

            SaveCommand = new RelayCommand(o => _bms.UnitOfWork.SaveAll());
        }

    }
}

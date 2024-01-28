
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using MatuszewskiStasiak.SuperBooks.Core;

namespace MatuszewskiStasiak.SuperBooks.MAUI
{
    public partial class BookViewModel : ObservableObject, IBook
    {
        [ObservableProperty]
        private Guid id;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private IPublisher? publisher;

        [ObservableProperty]
        private int yearPublished;

        [ObservableProperty]
        private BookType type;

        public BookViewModel(IBook book)
        {
            Name = book.Name;
            Publisher = book.Publisher;
            YearPublished = book.YearPublished;
            Type = book.Type;
            Id = book.Id;
        }

    }
}

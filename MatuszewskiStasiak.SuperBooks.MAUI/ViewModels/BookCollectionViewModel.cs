
using MatuszewskiStasiak.SuperBooks.Interfaces;
using MatuszewskiStasiak.SuperBooks.Core;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatuszewskiStasiak.SuperBooks;
using MatuszewskiStasiak.SuperBooks.BLC;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MatuszewskiStasiak.SuperBooks.MAUI
{
    public partial class BookCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BookViewModel> books;

        private BLC.BLC _blc;

        public BookCollectionViewModel(BLC.BLC blc)
        {
            _blc = blc;
            Books = new ObservableCollection<BookViewModel>();

            foreach (IBook book in _blc.GetBooks())
            {
                Books.Add(new BookViewModel(book));
                Debug.WriteLine(book.Name);
            }

        }
    }
}

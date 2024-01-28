using Cars.Interfaces;
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
using CarsAppMAUI.ViewModels;

namespace CarsAppMAUI.ViewModels
{
    public partial class BookcollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BookViewModel> books;

        [ObservableProperty]
        private BLC _blc;

        public BookcollectionViewModel(BLC blc)
        {
            _blc = blc;
            books = new ObservableCollection<BookViewModel>();

            foreach (IBook book in _blc.GetBooks())
            {
                books.Add(new BookViewModel(book));
            }
        }
    }
}

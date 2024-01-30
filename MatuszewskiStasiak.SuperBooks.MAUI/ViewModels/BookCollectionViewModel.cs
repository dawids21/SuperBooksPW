
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
using System.IO;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Globalization;

namespace MatuszewskiStasiak.SuperBooks.MAUI.ViewModels
{
    public partial class BookCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BookViewModel> books;

        private ObservableCollection<IPublisher> allPublishers;
        public ObservableCollection<IPublisher> AllPublishers
        {
            get { return allPublishers; }
            set
            {
                if (value != allPublishers)
                {
                    allPublishers = value;
                    OnPropertyChanged(nameof(allPublishers));
                }
            }
        }

        private BLC.BLC _blc;

        
        private BookViewModel bookEdit;

        public BookViewModel BookEdit
        {
            get { return bookEdit; }
            set { SetProperty(ref bookEdit, value); }
        }

        [ObservableProperty]
        private bool isEditing = false;

        [ObservableProperty]
        private bool isCreating = false;

        public ICommand CancelCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public BookCollectionViewModel(BLC.BLC blc)
        {
            _blc = blc;
            Books = new ObservableCollection<BookViewModel>();

            foreach (IBook book in _blc.GetBooks())
            {
                Books.Add(new BookViewModel(book));
                Debug.WriteLine(book.Name);
            }
            RefreshPublishers();

            isEditing = false;
            isCreating = false;
            BookEdit = null;

            CancelCommand = new Command(
                execute: () =>
                {
                    BookEdit.PropertyChanged -= OnBookEditPropertyChanged;
                    BookEdit = null;
                    IsEditing = false;
                    IsCreating = false;
                    RefreshCanExecute();
                },
                canExecute: () => isEditing || isCreating
                );
            SearchCommand = new Command(
            execute: () =>
            {
                FilterBooks();
    });
        }
        [RelayCommand(CanExecute = nameof(CanCreateNewBook))]
        private void CreateNewBook()
        {
            BookEdit = new BookViewModel();
            if (allPublishers.Count() > 0)
            {
                BookEdit.Publisher = allPublishers.ElementAt(0);
            }
            else
            {
                return;
            }
            BookEdit.PropertyChanged += OnBookEditPropertyChanged;
            IsCreating = true;
            RefreshCanExecute();
        }

        private bool CanCreateNewBook()
        {
            return !isEditing;
        }

        [RelayCommand(CanExecute = nameof(CanEditBookBeSaved))]
        private void SaveBook()
        {
            if (IsCreating)
            {
                _blc.CreateNewBook(BookEdit.Name,
                    BookEdit.Publisher.ID,
                    BookEdit.YearPublished,
                    BookEdit.Type
                    );
            }
            else
            {
                _blc.EditBook(
                    BookEdit.Id,
                    BookEdit.Name,
                    BookEdit.Publisher.ID,
                    BookEdit.YearPublished,
                    BookEdit.Type
                    );
            }
            BookEdit.PropertyChanged -= OnBookEditPropertyChanged;
            BookEdit = null;
            IsEditing = false;
            isCreating = false;
            RefreshCanExecute();
            RefreshBooks();
        }

        private bool CanEditBookBeSaved()
        {
            return BookEdit != null &&
                BookEdit.Name != null &&
                BookEdit.Name.Length > 1 &&
                BookEdit.YearPublished > 0 &&
                BookEdit.YearPublished <= 2024;
        }

        public void EditBook(BookViewModel movie)
        {
            BookEdit = movie;
            BookEdit.PropertyChanged += OnBookEditPropertyChanged;
            IsEditing = true;
            isCreating = false;
            RefreshCanExecute();
        }

        [RelayCommand(CanExecute = nameof(CanEditBookBeSaved))]
        public void DeleteBook()
        {
            _blc.DeleteBook(BookEdit.Id);
            isCreating = false;
            IsEditing = false;
            BookEdit = null;
            RefreshCanExecute();
            RefreshBooks();
        }

        [ObservableProperty]
        public string searchText;

        [ObservableProperty]
        public string selectedFilterCriteria;

        private void FilterBooks()
        {
            RefreshBooks();
            if (SelectedFilterCriteria == "Name")
            {
                Books = new ObservableCollection<BookViewModel>(Books.Where(f => f.Name.ToLower().Contains(SearchText.ToLower())));
            }
            else if (SelectedFilterCriteria == "Type")
            {
                Books = new ObservableCollection<BookViewModel>(Books.Where(f => f.Type.ToString().ToLower().Contains(SearchText.ToLower())));
            }
            else if (SelectedFilterCriteria == "Publisher Name")
            {
                Books = new ObservableCollection<BookViewModel>(Books.Where(f => f.Publisher.Name.ToLower().Contains(SearchText.ToLower())));
            }
        }

        private void OnBookEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SaveBookCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            CreateNewBookCommand.NotifyCanExecuteChanged();
            SaveBookCommand.NotifyCanExecuteChanged();
            DeleteBookCommand.NotifyCanExecuteChanged();
            (CancelCommand as Command).ChangeCanExecute();
        }

        public void RefreshBooks()
        {
            if (Books == null)
            {
                Books = new ObservableCollection<BookViewModel>();
            }
            Books.Clear();
            foreach (IBook book in _blc.GetBooks())
            {
                Books.Add(new BookViewModel(book));
            }
        }

        public void RefreshPublishers()
        {
            allPublishers = new ObservableCollection<IPublisher>(_blc.GetPublishers());
            OnPropertyChanged(nameof(AllPublishers));
        }

    }
    public class MyEnumToIntConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            BookType bookType = (BookType)value;
            int result = (int)bookType;
            return result;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int val = (int)value;
            if (val != -1)
                return (BookType)value;
            else
                return 0;

        }
    }

}


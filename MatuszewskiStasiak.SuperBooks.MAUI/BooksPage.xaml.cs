using MatuszewskiStasiak.SuperBooks.MAUI.ViewModels;
using System.Diagnostics;

namespace MatuszewskiStasiak.SuperBooks.MAUI;

public partial class BooksPage : ContentPage
{
	public BooksPage(BookCollectionViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
        viewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(viewModel.Books))
            {
                var updatedBooks = viewModel.Books;
                BookList.ItemsSource = updatedBooks;
            }
        };

    }

    void ListView_ItemTapped_1(object sender, ItemTappedEventArgs e)
    {
        var bookViewModel = (e.Item as BookViewModel).Clone() as BookViewModel;
        bookViewModel.Publisher = (BindingContext as BookCollectionViewModel).AllPublishers.FirstOrDefault(p => p.ID == bookViewModel.Publisher.ID);
        (BindingContext as BookCollectionViewModel).RefreshPublishers();
        (BindingContext as BookCollectionViewModel).EditBook(bookViewModel);

    }
}
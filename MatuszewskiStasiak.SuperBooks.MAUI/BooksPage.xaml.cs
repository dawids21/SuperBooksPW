namespace MatuszewskiStasiak.SuperBooks.MAUI;

public partial class BooksPage : ContentPage
{
	public BooksPage(BookCollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
using CarsAppMAUI.ViewModels;

namespace CarsAppMAUI;

public partial class BooksPage : ContentPage
{
	public BooksPage(BookCollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
namespace MatuszewskiStasiak.SuperBooks.MAUI;
using MatuszewskiStasiak.SuperBooks.MAUI.ViewModels;

public partial class PublishersPage : ContentPage
{
	public PublishersPage(PublisherCollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var publishersViewModel = (e.Item as PublisherViewModel).Clone() as PublisherViewModel;
        (BindingContext as PublisherCollectionViewModel).EditPublisher(publishersViewModel);
    }
}
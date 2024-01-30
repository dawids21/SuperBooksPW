using CommunityToolkit.Mvvm.ComponentModel;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuszewskiStasiak.SuperBooks.MAUI.ViewModels
{
    public partial class PublisherViewModel: ObservableObject, IPublisher
    {
        [ObservableProperty]
        private Guid iD;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? address;

        [ObservableProperty]
        private int yearCreated;

        [ObservableProperty]
        private List<IBook>? books;

        public PublisherViewModel(IPublisher publisher)
        {
            Name = publisher.Name;
            Address = publisher.Address;
            YearCreated = publisher.YearCreated;
            Books = publisher.Books;
            ID = publisher.ID;
        }

        public PublisherViewModel()
        {
        }

        public object Clone()
        {
            return new PublisherViewModel(this);
        }
    }
}

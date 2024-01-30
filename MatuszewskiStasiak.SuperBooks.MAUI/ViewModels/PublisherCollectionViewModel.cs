using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MatuszewskiStasiak.SuperBooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MatuszewskiStasiak.SuperBooks.MAUI.ViewModels
{
    public partial class PublisherCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PublisherViewModel> publishers;

        private BLC.BLC _blc;

        private PublisherViewModel publisherEdit;

        public PublisherViewModel PublisherEdit
        {
            get { return publisherEdit; }
            set { SetProperty(ref publisherEdit, value); }
        }

        [ObservableProperty]
        private bool isEditing = false;
        [ObservableProperty]
        private bool isCreating = false;

        public ICommand CancelCommand { get; set; }

        public PublisherCollectionViewModel(BLC.BLC blc)
        {
            _blc = blc;
            Publishers = new ObservableCollection<PublisherViewModel>();

            foreach (IPublisher publisher in _blc.GetPublishers())
            {
                Publishers.Add(new PublisherViewModel(publisher));
                Debug.WriteLine(publisher.Name);
            }
            CancelCommand = new Command(
                execute: () =>
                {
                    PublisherEdit.PropertyChanged -= OnPublisherEditPropertyChanged;
                    PublisherEdit = null;
                    IsEditing = false;
                    isCreating = false;
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return IsEditing || isCreating;
                });
        }

        [RelayCommand(CanExecute = nameof(CanCreateNewPublisher))]
        private void CreateNewPublisher()
        {
            PublisherEdit = new PublisherViewModel();
            PublisherEdit.PropertyChanged += OnPublisherEditPropertyChanged;
            IsCreating = true;
            RefreshCanExecute();
        }

        private bool CanCreateNewPublisher()
        {
            return !IsEditing;
        }

        [RelayCommand(CanExecute = nameof(CanEditPublisherBeSaved))]
        private void SavePublisher()
        {

            if (IsCreating)
            {
                var producer = _blc.CreateNewPublisher(PublisherEdit.Name, PublisherEdit.Address, PublisherEdit.YearCreated);
            }
            else
            {
                _blc.EditPublisher(PublisherEdit.ID, PublisherEdit.Name, PublisherEdit.Address, PublisherEdit.YearCreated);
            }
            PublisherEdit.PropertyChanged -= OnPublisherEditPropertyChanged;
            PublisherEdit = null;
            IsEditing = false;
            IsCreating = false;
            RefreshCanExecute();
            ReloadPublishers();
        }

        private bool CanEditPublisherBeSaved()
        {
            return this.PublisherEdit != null &&
                   PublisherEdit.Name != null &&
                   PublisherEdit.Name.Length >= 1;
        }

        public bool IsCurrentlyEditing()
        {
            return IsEditing || IsCreating;
        }


        [RelayCommand(CanExecute = nameof(CanEditPublisherBeSaved))]
        public void DeletePublisher()
        {
            _blc.DeletePublisher(PublisherEdit.ID);
            IsCreating = false;
            IsEditing = false;
            PublisherEdit = null;
            RefreshCanExecute();
            ReloadPublishers();
        }

        void OnPublisherEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SavePublisherCommand.NotifyCanExecuteChanged();
        }


        public void EditPublisher(PublisherViewModel publisher)
        {
            PublisherEdit = publisher;
            PublisherEdit.PropertyChanged += OnPublisherEditPropertyChanged;
            IsEditing = true;
            IsCreating = false;
            RefreshCanExecute();
        }

        private void RefreshCanExecute()
        {
            CreateNewPublisherCommand.NotifyCanExecuteChanged();
            SavePublisherCommand.NotifyCanExecuteChanged();
            DeletePublisherCommand.NotifyCanExecuteChanged();
            (CancelCommand as Command)?.ChangeCanExecute();
        }

        void ReloadPublishers()
        {
            Publishers.Clear();
            foreach (IPublisher publisher in _blc.GetPublishers())
            {
                Publishers.Add(new PublisherViewModel(publisher));
            }
            OnPropertyChanged(nameof(Publishers));
        }

    }

}


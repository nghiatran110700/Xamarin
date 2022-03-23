using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TestApi.Model;
using TestApi.Service;

namespace TestApi.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        Itenancy webAPIService;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Tenancy> items;
        public ObservableCollection<Tenancy> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisepropertyChanged("Items");
            }
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            webAPIService = new Itenancy();
            
            items = new ObservableCollection<Tenancy>();
            GetData();
        }
        async void GetData()
        {
            Items = await webAPIService.RefreshDataAsync();
        }
        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

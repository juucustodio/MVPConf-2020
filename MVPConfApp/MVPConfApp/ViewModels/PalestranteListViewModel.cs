using MVPConfApp.Models;
using MVPConfApp.Views;
using MVPConfApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVPConfApp.ViewModels
{
    public class PalestranteListViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Palestrante> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        private readonly RestClient _restClient;

        public PalestranteListViewModel()
        {
            Title = "Palestrantes";
            Items = new ObservableCollection<Palestrante>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _restClient = new RestClient();
            ItemTapped = new Command<Item>(OnItemSelected);

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _restClient.GetList<Palestrante>("9ecb1fb9-723f-4c77-a9eb-791f1d7d9162");
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(PalestraDetailPage)}?{nameof(PalestraDetailViewModel.ItemId)}={item.Id}");
        }
    }
}

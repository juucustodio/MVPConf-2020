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
using MVVMCoffee.ViewModels;
using System.Linq;

namespace MVPConfApp.ViewModels
{
    public class PalestranteListViewModel : BaseViewModel
    {
        private Palestrante _selectedItem;

        public ObservableCollection<Palestrante> Items { get; set; }
        public Command LoadItemsCommand { get; }
        public Command<Palestrante> ItemTapped { get; }

        private readonly RestClient _restClient;

        public string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public PalestranteListViewModel()
        {
            Title = "Palestrantes";
            Items = new ObservableCollection<Palestrante>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _restClient = new RestClient();
            ItemTapped = new Command<Palestrante>(OnItemSelected);

        }

        async Task ExecuteLoadItemsCommand()
        {
            Busy = true;

            try
            {
                Items.Clear();
                var items = await _restClient.GetList<Palestrante>("Speaker?code=Aw1RNg7WYisFy7KRTTWEJLr4QQnL/eQnrOaUJ2wYYnRFJA/oAAMpdg==");
                items = items.OrderBy(keySelector: x => x.Name).ToList();
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Algo deu errado :( ", "OK");
            }
            finally
            {
                Busy = false;
            }
        }

        public void OnAppearing()
        {
            Busy = true;
            SelectedItem = null;
        }

        public Palestrante SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Palestrante item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PalestranteDetailPage)}?{nameof(PalestranteDetailViewModel.ItemId)}={item.Id}");
        }
    }
}

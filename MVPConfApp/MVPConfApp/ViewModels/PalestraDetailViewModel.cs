using MVPConfApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMCoffee.ViewModels;
using MVPConfApp.Services;

namespace MVPConfApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PalestraDetailViewModel : BaseViewModel
    {
        private readonly RestClient _restClient;
        public PalestraDetailViewModel()
        {
            _restClient = new RestClient();
        }

        public bool isVisible;
        public bool IsVisible
        {
            get { return !Busy; }
            set { SetProperty(ref isVisible, value); }
        }
        public string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private Palestra item;
        public Palestra Item
        {
            get { return item; }
            set { SetProperty(ref item, value); }
        }

        private string itemId;

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string id)
        {
            try
            {
                Busy = true;
                Item = _restClient.Get<Palestra>("Talk/" + id + "?code=5aYiUz43SZmQctRfSwyBSr5ZgvTJMklJgTqe8TWnRZP3LWme5kjZ7Q==");
                Item.Date = DateTime.Parse(Item.Scheduler).ToUniversalTime();

                for(var x = 0; x < Item.Speakers.Count; x++)
                {
                    Item.Speakers[x] = _restClient.Get<Palestrante>(Item.Speakers[x].Url + "?code=IVXnMGw3JirGrBHGI5DrcDYxbai1eW1eQUYhnrucJ52jH4oyBkrfPw==");

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Algo deu errado :( ", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            finally
            {
                Busy = false;
            }
        }
    }
}

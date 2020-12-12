using MVPConfApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMCoffee.ViewModels;
using System.Windows.Input;
using Xamarin.Essentials;
using MVPConfApp.Services;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace MVPConfApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PalestranteDetailViewModel : BaseViewModel
    {
        private readonly RestClient _restClient;
        public PalestranteDetailViewModel()
        {
            Item = new Palestrante();
            _restClient = new RestClient();
        }

        public string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private Palestrante item;
        public Palestrante Item
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
                Item =  _restClient.Get<Palestrante>("Speaker/" + id + "?code=IVXnMGw3JirGrBHGI5DrcDYxbai1eW1eQUYhnrucJ52jH4oyBkrfPw==");
                                
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Category", "PalestranteList" },
                    { "ErrorMessage", ex.Message },
                    { "Wi-fi", Connectivity.NetworkAccess.ToString() },
                    { "OS", Device.RuntimePlatform }
                };
                Crashes.TrackError(ex, properties);

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

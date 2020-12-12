using MVPConfApp.Models;
using MVPConfApp.Services;
using MVPConfApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMCoffee.ViewModels;
using System.Linq;
using Microsoft.AppCenter.Crashes;
using Xamarin.Essentials;

namespace MVPConfApp.ViewModels
{
    public class PalestraListViewModel : BaseViewModel
    {
        private Palestra _selectedItem;

        public ObservableCollection<Palestra> Items { get; }

        public ObservableCollection<Palestra> itemsVisible;
        public ObservableCollection<Palestra> ItemsVisible
        {
            get { return itemsVisible; }
            set { SetProperty(ref itemsVisible, value); }
        }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Palestra> ItemTapped { get; }

        private readonly RestClient _restClient;

        public IList<Track> tracks;
        public IList<Track> Tracks
        {
            get { return tracks; }
            set { SetProperty(ref tracks, value); }
        }

        public Track selectedTrack;
        public Track SelectedTrack
        {
            get { return selectedTrack; }
            set 
            {

                SetProperty(ref selectedTrack, value);
                ItemsVisible.Clear();
                foreach (var item in Items.Where(x => x.TrackObj.Id == selectedTrack.Id).ToList())
                {
                     ItemsVisible.Add(item);
                }
            }
        }

        public string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public PalestraListViewModel()
        {
            Title = "Palestras";
            Items = new ObservableCollection<Palestra>();
            ItemsVisible = new ObservableCollection<Palestra>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
            _restClient = new RestClient();
            ItemTapped = new Command<Palestra>(OnItemSelected);
            
            Tracks = new List<Track>();

            for(int x = 0; x <16; x++)
            {
                Tracks.Add(new Track((TrackId)x));
            }

            SelectedTrack = new Track(0);
        }

        async Task ExecuteRefreshItemsCommand(Track selected)
        {
            Busy = true;

            try
            {
                if (Items.Count == 0)
                    return;

                ItemsVisible.Clear();
                foreach (var item in Items.Where(x => x.TrackObj.Id == selected.Id).ToList())
                {
                    ItemsVisible.Add(item);
                }
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Category", "PalestraList" },
                    { "ErrorMessage", ex.Message },
                    { "Wi-fi", Connectivity.NetworkAccess.ToString() },
                    { "OS", Device.RuntimePlatform }
                };
                Crashes.TrackError(ex, properties);
                await Application.Current.MainPage.DisplayAlert("Erro", "Algo deu errado :( ", "OK");
                
            }
            finally
            {
                Busy = false;
            }
        }

        async void ExecuteLoadItemsCommand()
        {
            Busy = true;

            try
            {
                ItemsVisible.Clear();
                Items.Clear();
                var items = await _restClient.GetList<Palestra>("Talk?code=JwhtwnIZkZNPa82aGH27saF4aEJD24Q2AWyu9aRzbAwB5EMaEkuldw==");
                foreach (var item in items)
                {
                    if (item.Visible)
                    {
                        if (item.Track.Contains("Desenvolvimento de Software"))
                            item.TrackObj = new Track(Models.TrackId.Desenvolvimento);
                        else if (item.Track.Contains("Azure | Blockchain"))
                            item.TrackObj = new Track(Models.TrackId.AzureBlockchain);
                        else if (item.Track.Contains("Banco de Dados"))
                            item.TrackObj = new Track(Models.TrackId.Banco);
                        else if (item.Track.Contains("DevOps | Containers"))
                            item.TrackObj = new Track(Models.TrackId.DevOpsContainers);
                        else if (item.Track.Contains("Gerenciamento de Projetos"))
                            item.TrackObj = new Track(Models.TrackId.GerenciamentoProjeto);
                        else if (item.Track.Contains("IA | Machine Learning | Computação Cognitiva | ChatBots"))
                            item.TrackObj = new Track(Models.TrackId.IaMachineLearningChatBots);
                        else if (item.Track.Contains("IoT"))
                            item.TrackObj = new Track(Models.TrackId.IoT);
                        else if (item.Track.Contains("IT Pro | Infraestrutura"))
                            item.TrackObj = new Track(Models.TrackId.ItInfraestrutura);
                        else if (item.Track.Contains("LGPD"))
                            item.TrackObj = new Track(Models.TrackId.Lgpd);
                        else if (item.Track.Contains("Office & Produtividade"))
                            item.TrackObj = new Track(Models.TrackId.Office);
                        else if (item.Track.Contains("Power BI"))
                            item.TrackObj = new Track(Models.TrackId.PowerBi);
                        else if (item.Track.Contains("Segurança da Informação"))
                            item.TrackObj = new Track(Models.TrackId.Seguranca);
                        else if (item.Track.Contains("Espanhol"))
                            item.TrackObj = new Track(Models.TrackId.Espanhol);
                        else if (item.Track.Contains("Big Data"))
                            item.TrackObj = new Track(Models.TrackId.BigData);
                        else if (item.Track.Contains("Casos de Sucesso"))
                            item.TrackObj = new Track(Models.TrackId.Cases);
                        else if (item.Track.Contains("Mobile"))
                            item.TrackObj = new Track(Models.TrackId.Mobile);

                        item.Date = DateTime.Parse(item.Scheduler).ToUniversalTime();

                        Items.Add(item);
                    }
                }

                if (SelectedTrack == null)
                    SelectedTrack = new Track(0);
                
                await ExecuteRefreshItemsCommand(SelectedTrack);
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Category", "PalestraList" },
                    { "ErrorMessage", ex.Message },
                    { "Wi-fi", Connectivity.NetworkAccess.ToString() },
                    { "OS", Device.RuntimePlatform }
                };
                Crashes.TrackError(ex, properties);

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

        public Palestra SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Palestra item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PalestraDetailPage)}?{nameof(PalestraDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
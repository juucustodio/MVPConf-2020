using MVPConfApp.Models;
using MVPConfApp.Services;
using MVPConfApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVPConfApp.ViewModels
{
    public class PalestraListViewModel : BaseViewModel
    {
        private Palestra _selectedItem;

        public ObservableCollection<Palestra> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command RefreshItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Palestra> ItemTapped { get; }

        private readonly RestClient _restClient;

        public IList<Track> tracks;
        public IList<Track> Tracks
        {
            get { return tracks; }
            set { SetProperty(ref tracks, value); }
        }

        public Track SelectedTrack;

        public PalestraListViewModel()
        {
            Title = "Palestras";
            Items = new ObservableCollection<Palestra>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            RefreshItemsCommand = new Command(async () => await ExecuteRefreshItemsCommand());
            _restClient = new RestClient();
            ItemTapped = new Command<Palestra>(OnItemSelected);
            SelectedTrack = new Track(0);

            Tracks = new List<Track>();

            for(int x = 0; x <16; x++)
            {
                Tracks.Add(new Track((TrackId)x));
            }
        }

        async Task ExecuteRefreshItemsCommand()
        { 
        
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _restClient.GetList<Palestra>("d287f08d-11c2-41d0-a766-f5cd962ae9eb");
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

                        Items.Add(item);
                    }
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
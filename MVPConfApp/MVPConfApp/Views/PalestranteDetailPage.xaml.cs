using MVPConfApp.ViewModels;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MVPConfApp.Views
{
    public partial class PalestranteDetailPage : ContentPage
    {
        private PalestranteDetailViewModel ViewModel => BindingContext as PalestranteDetailViewModel;
        public PalestranteDetailPage()
        {
            InitializeComponent();
            BindingContext = new PalestranteDetailViewModel();
        }

        private async void Linkedin_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ViewModel.Item.Linkedin))
                await Browser.OpenAsync(ViewModel.Item.Linkedin);
            else
                await Application.Current.MainPage.DisplayAlert("Que pena", "Esse palestrante não forneceu essa informação :(", "OK");
        }

        private async void Twitter_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ViewModel.Item.Twitter))
                await Browser.OpenAsync(ViewModel.Item.Twitter);
            else
                await Application.Current.MainPage.DisplayAlert("Que pena", "Esse palestrante não forneceu essa informação :(", "OK");
        }

        private async void Mvp_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ViewModel.Item.Site))
                await Browser.OpenAsync(ViewModel.Item.Site);
            else
                await Application.Current.MainPage.DisplayAlert("Que pena", "Esse palestrante não forneceu essa informação :(", "OK");
        }
    }
}
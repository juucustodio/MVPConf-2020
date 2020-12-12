using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVPConfApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Application.Current.MainPage.DisplayAlert("ATENÇÃO", "Este app não é o app oficial do evento.  Mas poderia ser.. ;) ", "OK");

        }
    }
}
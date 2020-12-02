using MVPConfApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MVPConfApp.Views
{
    public partial class PalestraDetailPage : ContentPage
    {
        public PalestraDetailPage()
        {
            InitializeComponent();
            BindingContext = new PalestraDetailViewModel();
        }
    }
}
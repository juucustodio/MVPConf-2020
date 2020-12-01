using MVPConfApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MVPConfApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
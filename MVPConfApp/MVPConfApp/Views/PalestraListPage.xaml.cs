using MVPConfApp.Models;
using MVPConfApp.ViewModels;
using MVPConfApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVPConfApp.Views
{
    public partial class PalestraListPage : ContentPage
    {
        PalestraListViewModel _viewModel;

        public PalestraListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PalestraListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
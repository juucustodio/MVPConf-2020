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
    public partial class PalestranteListPage : ContentPage
    {
        PalestranteListViewModel _viewModel;

        public PalestranteListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PalestranteListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
﻿using MVPConfApp.Services;
using MVPConfApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVPConfApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

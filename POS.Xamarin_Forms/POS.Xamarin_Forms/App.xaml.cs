using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POS.Xamarin_Forms.Services;
using POS.Xamarin_Forms.Views;

namespace POS.Xamarin_Forms
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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

using System;
using TH_Essentials.Services;
using TH_Essentials.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TH_Essentials
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

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ViajesMVVM.Views;

namespace ViajesMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new DetallesViajeView());
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

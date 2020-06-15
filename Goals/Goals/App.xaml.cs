
using Goals.Views;
using System;
using Xamarin.Forms;

namespace Goals
{
    public partial class App : Application
    {
        public string CurrentUser { get; set; } 
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HomePage());
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

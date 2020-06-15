using Goals.Extensions;
using Goals.Localization;
using Goals.ViewModels;
using Goals.Views.Settings;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePageViewModel Context => BindingContext as HomePageViewModel;

        public HomePage()
        {
            BindingContext = new HomePageViewModel();
            InitializeComponent();
            this.Appearing += HomePageAppearing;
        }

        private void HomePageAppearing(object sender, EventArgs e)
        {
            Context.LoadData();
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await (sender as Button).ScaleAnimation(0.45, 0.4);
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void GoalsClicked(object sender, EventArgs e)
        {
            await (sender as Button).ScaleAnimation(0.55, 0.5);
        }

        private async void WalletClicked(object sender, EventArgs e)
        {
            await (sender as Button).ScaleAnimation(0.55, 0.5);
            //await Navigation.PushAsync(new WalletHomePage());
        }
    }
}
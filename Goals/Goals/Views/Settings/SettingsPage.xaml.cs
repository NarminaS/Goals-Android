using Goals.Extensions;
using Goals.ViewModels.Settings;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            BindingContext = new SettingsViewModel();
            InitializeComponent();
        }

        private async void BackToHomeClicked(object sender, EventArgs e)
        {
            await (sender as Button).ScaleAnimation(0.75, 0.5);
            await Navigation.PopAsync();
        }

        private async void CurrencyClicked(object sender, EventArgs e)
        {
            await (sender as Button).ScaleAnimation(1.2, 1);
            await Navigation.PushAsync(new CurrencyPage());
        }

        private async void LanguageClicked(object sender, EventArgs e)
        {
            await (sender as Button).ScaleAnimation(1.2, 1);
            await Navigation.PushAsync(new LanguagePage());
        }

        private async void TogglerClicked(object sender, EventArgs e)   
        {
            await (sender as Button).ScaleAnimation(1.2, 1);
        }
    }
}
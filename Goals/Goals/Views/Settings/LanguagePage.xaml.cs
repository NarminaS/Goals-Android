using Android.Widget;
using Goals.Extensions;
using Goals.ViewModels.Settings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        public LanguageViewModel Context
        {
            get => BindingContext as LanguageViewModel;
        }
        public LanguagePage()
        {
            BindingContext = new LanguageViewModel();
            Context.LanguageSwitched += LanguageSwitched;
            InitializeComponent();
        }

        private void LanguageSwitched(object sender, EventArgs e)
        {
            string message = "LanguageChangedAlert".GetLocalizedValue();
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        private async void BackToSettingsClicked(object sender, EventArgs e)
        {
            await (sender as Xamarin.Forms.Button).ScaleAnimation(0.75, 0.5);
            await Navigation.PopAsync();
        }
    }
}
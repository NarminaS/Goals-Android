using Goals.Extensions;
using Goals.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencyPage : ContentPage
    {
        public CurrencyPage()
        {
            BindingContext = new CurrencyViewModel();
            InitializeComponent();
        }

        private async void BackToSettingsClicked(object sender, EventArgs e)    
        {
            await (sender as Button).ScaleAnimation(0.75, 0.5);
            await Navigation.PopAsync();
        }
    }
}
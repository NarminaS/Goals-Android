using Goals.DTO;
using Goals.ViewModels;
using Goals.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Task = System.Threading.Tasks.Task;

namespace Goals
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MissionListViewModel();
            this.Appearing += MainPage_Appearing;
        }

        private async void MainPage_Appearing(object sender, EventArgs e)
        {
            BindingContext = await Task.Run(async () => await MissionListViewModel.LoadData());
        }

        public async Task OpenModal()
        {
            await PopupNavigation.Instance.PushAsync(new MissionModalPage());
        }

        private async void MissionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                var selectedMissionId = ((sender as ListView).SelectedItem as MissionSimpleDto).Id;
                await Navigation.PushAsync(new MissionPage(selectedMissionId)); //MissionTabbedPage
            }
        }
    }
}

using Goals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goals.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MissionTabbedPage : TabbedPage
    {
        private readonly int currentMissionId;
        public MissionTabbedPage()
        {
            InitializeComponent();
        }

        public MissionTabbedPage(int id)
        {
            currentMissionId = id;
            BindingContext = new MissionPageViewModel(currentMissionId);
            InitializeComponent();
            this.Appearing += MissionPageAppearing;
        }

        private async void MissionPageAppearing(object sender, EventArgs e)
        {
            BindingContext = await Task.Run(async () => await MissionPageViewModel.LoadData(currentMissionId));
        }

        private async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
    }
}
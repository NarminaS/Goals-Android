using Android.OS;
using Goals.Commands;
using Goals.DTO;
using Goals.Extensions;
using Goals.Helpers;
using Goals.Services.Repositories.Concrete;
using Goals.Views;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Goals.ViewModels
{
    public class MissionListViewModel : INotifyPropertyChanged
    {
        public MissionListViewModel()
        {
            Missions = new ObservableCollection<MissionSimpleDto>();
            OpenModalCommand = new OpenModalCommand(this);
        }

        private bool loading = true;
        public bool Loading
        {
            get { return loading; }
            set
            {
                loading = value;
                OnPropertyChanged("Loading");
            }
        }

        private MissionSimpleDto selectedMission;
        public MissionSimpleDto SelectedMission
        {
            get { return selectedMission; }
            set
            {
                selectedMission = value;
                OnPropertyChanged("SelectedMission");
            }
        }


        public ICommand OpenModalCommand { get; }

        public ObservableCollection<MissionSimpleDto> Missions { get; set; }

        public static async Task<MissionListViewModel> LoadData()
        {
            MissionListViewModel model = new MissionListViewModel();
            ConnectivityHelper<List<MissionSimpleDto>> connectable = new ConnectivityHelper<List<MissionSimpleDto>>();
            MissionRepository repository = new MissionRepository();
            var missions = await connectable.MakeRemoteCall(async () => await repository.GetMissionsForList(), () => {});
            model.Missions.AddRange(missions);
            model.Loading = false;
            return model;
        }

        public async Task OpenModal()
        {
            await PopupNavigation.Instance.PushAsync(new MissionModalPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

using Goals.DTO;
using Goals.Services.Repositories.Concrete;
using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goals.ViewModels
{
    class MissionCreateViewModel : INotifyPropertyChanged
    {
        public ICommand CreateMissionCommand { get; private set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private bool missionCreating = false;
        public bool MissionCreating
        {
            get { return missionCreating; }
            set
            {
                missionCreating = value;
                OnPropertyChanged("MissionCreating");
            }
        }

        private DateTime? deadline = DateTime.Today.AddDays(1);
        public DateTime? Deadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                OnPropertyChanged("Deadline");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private decimal totalSum;
        public decimal TotalSum
        {
            get { return totalSum; }
            set
            {
                totalSum = value;
                OnPropertyChanged("TotalSum");
            }
        }

        public MissionCreateViewModel()
        {
            CreateMissionCommand = new Command( //TODO: Try to use my own CreateMissionCommand implementation
                    canExecute: (object param) =>
                    {
                        return !string.IsNullOrWhiteSpace(param as string);
                    },
                    execute: async (object param) => await Create());
        }

        public async Task<MissionSimpleDto> Create()
        {
            MissionCreateDto Mission = new MissionCreateDto { Name = Name, Deadline = Deadline, Description = Description, TotalSum = TotalSum };
            MissionCreating = true;
            MissionRepository repository = new MissionRepository();
            MissionSimpleDto mission = await repository.CreateForList(Mission);
            (Application.Current.MainPage.BindingContext as MissionListViewModel).Missions.Add(mission);
            MissionCreating = false;
            await CloseModal();
            return mission;
        }

        public async Task CloseModal()
        {
            await PopupNavigation.Instance.PopAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

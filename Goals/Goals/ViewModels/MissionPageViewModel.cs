using Goals.DTO;
using Goals.Extensions;
using Goals.Models;
using Goals.Services.Repositories.Concrete;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goals.ViewModels
{
    class MissionPageViewModel : INotifyPropertyChanged
    {
        private int missionId;
        public int MissionId
        {
            get { return missionId; }
            set
            {
                missionId = value;
                OnPropertyChanged("MissionId");
            }
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

        public int Id { get; set; }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }

        private DateTime? deadline;
        public DateTime? Deadline { get => deadline; set { deadline = value; OnPropertyChanged("Deadline"); } }

        private string description;
        public string Description { get => description; set { description = value; OnPropertyChanged("Description"); } }

        private decimal totalSum;
        public decimal TotalSum { get => totalSum; set { totalSum = value; OnPropertyChanged("TotalSum"); } }

        private decimal totalTransactions;
        public decimal TotalTransactions { get => totalTransactions; set { totalTransactions = value; OnPropertyChanged("TotalTransactions"); } }

        private bool isEditMode;
        public bool IsEditMode
        {
            get { return isEditMode; }
            set
            {
                isEditMode = value;
                OnPropertyChanged("IsEditMode");
            }
        }

        private float progress;
        public float Progress
        {
            get => progress;
            set
            {
                progress = value;
                ProgressNum = value / 100;
                OnPropertyChanged("Progress");
            }
        }

        private float progressNum;
        public float ProgressNum
        {
            get { return progressNum; }
            set
            {
                progressNum = value;
                OnPropertyChanged("ProgressNum");
            }
        }

        public ICommand SwitchToEditCommand { get; private set; }

        public ObservableCollection<TaskDetailDto> Tasks { get; set; }

        public MissionPageViewModel(int id)
        {
            MissionId = id;
            Tasks = new ObservableCollection<TaskDetailDto>();
            SwitchToEditCommand = new Command(
                canExecute: (object param) => !string.IsNullOrWhiteSpace(Name),
                execute: async (object param) =>
                {
                    if (IsEditMode)
                    {
                        await UpdateMission();
                    }
                    IsEditMode = !IsEditMode;
                });
        }

        public static async Task<MissionPageViewModel> LoadData(int id)
        {
            MissionPageViewModel model = new MissionPageViewModel(id);
            MissionRepository repository = new MissionRepository();
            var mission = await repository.GetForDetail(id);
            model.Id = id;
            model.Name = mission.Name;
            model.Deadline = mission.Deadline;
            model.Description = mission.Description;
            model.TotalSum = mission.TotalSum;
            model.TotalTransactions = mission.TotalTransactions;
            model.Progress = mission.Progress;
            model.Tasks.AddRange(mission.Tasks);
            model.Loading = false;
            return model;
        }

        private async System.Threading.Tasks.Task UpdateMission()
        {
            Loading = true;
            Mission missionToUpdate = new Mission { Id = MissionId, Name = Name, Deadline = Deadline, Description = Description, TotalSum = TotalSum };
            MissionRepository repository = new MissionRepository();
            await repository.Update(missionToUpdate);
            var mission = await repository.GetForDetail(missionToUpdate.Id);
            Name = mission.Name;
            Deadline = mission.Deadline;
            Description = mission.Description;
            TotalSum = mission.TotalSum;
            TotalTransactions = mission.TotalTransactions;
            Progress = mission.Progress;
            //TODO: Refactor Tasks.Clear(); 
            //Tasks.AddRange(mission.Tasks);
            Loading = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

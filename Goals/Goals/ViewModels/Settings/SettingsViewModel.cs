using Goals.Helpers;
using Goals.Services.Repositories.Abstract;
using Goals.Utils;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goals.ViewModels.Settings
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        private ImageSource photoPath;
        public ImageSource PhotoPath
        {
            get { return photoPath; }
            set
            {
                photoPath = value;
                OnPropertyChanged("PhotoPath");
            }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public ICommand ToggleSoundCommand { get; private set; }

        public ICommand ToggleNotificationCommand { get; private set; } 

        public SettingsViewModel()
        {
            var user = GetUser();
            PhotoPath = LoadAvatar(user.PhotoUrl);
            FullName = user.DisplayName;

            ToggleSoundCommand = new Command( 
                    canExecute: (object param) => true,
                    execute:  (object param) => EnableAppSounds = !EnableAppSounds);

            ToggleNotificationCommand = new Command( 
                    canExecute: (object param) => true,
                    execute: (object param) => EnableAppNotifications = !EnableAppNotifications);
        }

        private bool enableAppSounds = ApplicationSettings.EnableSounds;
        public bool EnableAppSounds
        {
            get { return enableAppSounds; }
            set
            {
                enableAppSounds = value;
                ApplicationSettings.EnableSounds = value;
                OnPropertyChanged("EnableAppSounds");
            }
        }

        private bool enableAppNotifications = ApplicationSettings.EnableNotificattions;
        public bool EnableAppNotifications
        {
            get { return enableAppNotifications; }
            set 
            { 
                enableAppNotifications = value;
                ApplicationSettings.EnableNotificattions = value;
                OnPropertyChanged("EnableAppNotifications");
            }
        }


        private ApplicationUser GetUser()
        {
            return DependencyService.Get<IAuthRepository>().GetUser();
        }

        private ImageSource LoadAvatar(string loggedInUserPhotoUrl)
        {
            string loggedInUserNoPhotoUrl = "Avatar_Photo.png";
            return loggedInUserPhotoUrl == null ? ImageSource.FromFile(loggedInUserNoPhotoUrl) : ImageSource.FromUri(new Uri(loggedInUserPhotoUrl));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

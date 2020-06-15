using Goals.Services.Repositories.Abstract;
using Goals.Utils;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Goals.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private readonly string loggedInUserNoPhotoUrl = "Avatar_Photo.png";

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

        public HomePageViewModel()
        {
            PhotoPath = ImageSource.FromFile(loggedInUserNoPhotoUrl);
        }

        private ImageSource LoadAvatar()
        {
            ApplicationUser user = DependencyService.Get<IAuthRepository>().GetUser();            
            if (user != null)
            {
                return user.PhotoUrl == null ? ImageSource.FromFile(loggedInUserNoPhotoUrl) : ImageSource.FromUri(new Uri(user.PhotoUrl));
            }
            else
            {
                return ImageSource.FromFile(loggedInUserNoPhotoUrl);
            }
        }

        public void LoadData()
        {
            PhotoPath = LoadAvatar();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

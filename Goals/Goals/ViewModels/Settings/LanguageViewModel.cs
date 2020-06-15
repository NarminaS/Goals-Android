using Goals.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goals.ViewModels.Settings
{
    public class LanguageViewModel : INotifyPropertyChanged
    {
        public event EventHandler LanguageSwitched;

        public string English { get => "en-US"; }
        public string Russian { get => "ru-RU"; }

        private ICommand toggleCultureCommand;
        public ICommand ToggleCultureCommand
        {
            get
            {
                return toggleCultureCommand ??
                      (toggleCultureCommand = new Command(
                canExecute: (object param) => true,
                execute: (object param) => SwitchCulture(param)));
            }
        }

        private string currentCulture;
        public string CurrentCulture
        {
            get { return ApplicationSettings.CurrentCulture; }
            set
            {
                currentCulture = value;
                ApplicationSettings.CurrentCulture = value;
                OnPropertyChanged("CurrentCulture");
            }
        }

        private ImageSource englishImage;
        public ImageSource EnglishImage
        {
            get
            {
                return englishImage;
            }
            set
            {
                englishImage = value;
                OnPropertyChanged("EnglishImage");
            }
        }

        private ImageSource russianImage;
        public ImageSource RussianImage
        {
            get
            {
                return russianImage;
            }
            set
            {
                russianImage = value;
                OnPropertyChanged("RussianImage");
            }
        }

        public LanguageViewModel()
        {
            EnglishImage = GetImageSource(English);
            RussianImage = GetImageSource(Russian);
        }

        private void SwitchCulture(object param)
        {
            CurrentCulture = param as string;
            EnglishImage = GetImageSource(English);
            RussianImage = GetImageSource(Russian);
            LanguageSwitched?.Invoke(this, new EventArgs());
        }

        private ImageSource GetImageSource(string lang)
        {
            string CurrencyName = lang == "en-US" ? "English" : "Russian";
            string ImageColor = CurrentCulture == lang ? "Light" : "Dark";
            return ImageSource.FromFile($"{CurrencyName}_{ImageColor}.png");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

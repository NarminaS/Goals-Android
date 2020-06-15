using Goals.Helpers;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goals.ViewModels.Settings
{
    class CurrencyViewModel : INotifyPropertyChanged
    {
        public string Manat { get => "AZN"; }

        public string Dollar { get => "USD"; }

        private ICommand toggleCurrencyCommand;
        public ICommand ToggleCurrencyCommand
        {
            get
            {
                return toggleCurrencyCommand ??
                      (toggleCurrencyCommand = new Command(
                canExecute: (object param) => true,
                execute: (object param) => SwitchCurrency(param)));
            }
        }

        private ImageSource dollarImage;
        public ImageSource DollarImage
        {
            get
            {
                return dollarImage;
            }
            set
            {
                dollarImage = value;
                OnPropertyChanged("DollarImage");
            }
        }

        private ImageSource manatImage;
        public ImageSource ManatImage
        {
            get
            {
                return manatImage;
            }
            set
            {
                manatImage = value;
                OnPropertyChanged("ManatImage");
            }
        }

        private string currentCurrency;
        public string CurrentCurrency
        {
            get { return ApplicationSettings.CurrentCurrency; }
            set
            {
                currentCurrency = value;
                ApplicationSettings.CurrentCurrency = value;
                OnPropertyChanged("CurrentCurrency");
            }
        }


        public CurrencyViewModel()
        {
            DollarImage = GetImageSource(Dollar);
            ManatImage = GetImageSource(Manat);
        }

        private void SwitchCurrency(object param)
        {
            CurrentCurrency = param as string;
            DollarImage = GetImageSource("USD");
            ManatImage = GetImageSource("AZN");
        }

        private ImageSource GetImageSource(string sign)
        {
            string CurrencyName = sign == "AZN" ? "Manat" : "Dollar";
            string ImageColor = CurrentCurrency == sign ? "Light" : "Dark";
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

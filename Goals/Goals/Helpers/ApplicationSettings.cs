using Goals.Localization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Globalization;
using Xamarin.Forms;

namespace Goals.Helpers
{
    public static class ApplicationSettings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Base Api Url
        private const string UrlBaseKey = "url_base";
        private static readonly string UrlBaseDefault = "https://goals-api.000webhostapp.com/";

        public static string UrlBase
        {
            get
            {
                return AppSettings.GetValueOrDefault(UrlBaseKey, UrlBaseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UrlBaseKey, value);
            }
        }
        #endregion


        #region Current Culture
        private const string CurrentCultureKey = "current_culture";
        private static readonly string CurrentCultureDefault = DependencyService.Get<ILocalize>().GetCurrentCultureInfo().Name;

        public static string CurrentCulture
        {
            get
            {
                return AppSettings.GetValueOrDefault(CurrentCultureKey, CurrentCultureDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CurrentCultureKey, value);
            }
        }

        public static string CultureReadable { get => new CultureInfo(CurrentCulture).NativeName; }
        #endregion

        #region Current Currency
        private const string CurrentCurrencyKey = "current_currency";
        private static readonly string CurrentCurrencyDefault = "AZN";

        public static string CurrentCurrency
        {
            get
            {
                return AppSettings.GetValueOrDefault(CurrentCurrencyKey, CurrentCurrencyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CurrentCurrencyKey, value);
            }
        }
        #endregion

        #region Enable/Disable Application Sounds
        private const string EnableSoundsKey = "enable_sounds";
        private static readonly bool EnableSoundsDefault = true;

        public static bool EnableSounds
        {
            get
            {
                return AppSettings.GetValueOrDefault(EnableSoundsKey, EnableSoundsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EnableSoundsKey, value);
            }
        }
        #endregion

        #region Enable/Disable Application Notification
        private const string EnableNotificationsKey = "enable_notifications";
        private static readonly bool EnableNotificationsDefault = true;

        public static bool EnableNotificattions
        {
            get
            {
                return AppSettings.GetValueOrDefault(EnableNotificationsKey, EnableNotificationsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EnableNotificationsKey, value);
            }
        }
        #endregion
    }
}

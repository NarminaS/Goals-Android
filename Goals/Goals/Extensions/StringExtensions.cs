using Goals.Helpers;
using Goals.Localization;
using Goals.MarkupExtensions;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace Goals.Extensions
{
    public static class StringExtensions
    {
        public static string GetLocalizedValue(this string source)
        {
            CultureInfo ci = new CultureInfo(ApplicationSettings.CurrentCulture);
            ResourceManager resourceManager = Resource.ResourceManager;
            return resourceManager.GetString(source, ci);
        }
    }
}

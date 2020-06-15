using System.Globalization;

namespace Goals.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}

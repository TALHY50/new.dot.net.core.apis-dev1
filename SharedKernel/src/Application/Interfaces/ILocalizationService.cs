using System.Globalization;
using System.Reflection;
using System.Resources;

namespace SharedKernel.Application.Interfaces
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key);
        string GetLocalizedStringWithCulture(string key, CultureInfo culture);
        CultureInfo SetCulture(string culture);
        ResourceManager SetReourceManager(CultureInfo resource,Assembly assembly);
        Assembly SetAssembly(Assembly assembly);
    }
}

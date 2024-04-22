using ACL.Services.Interface;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ACL.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager;
        private readonly CultureInfo _cultureInfo;

        public LocalizationService(string baseName, Assembly assembly, string culture)
        {
            _resourceManager = new ResourceManager(baseName, assembly);
            _cultureInfo = new CultureInfo(culture);
        }

        public string GetLocalizedString(string key)
        {
            return _resourceManager.GetString(key, _cultureInfo);
        }
    }
}

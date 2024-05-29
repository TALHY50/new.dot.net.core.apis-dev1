using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class LocalizationService(string baseName, Assembly assembly, string culture) : ILocalizationService
    {
        private ResourceManager _resourceManager = new(baseName, assembly);
        private CultureInfo _cultureInfo = new CultureInfo(culture);
#pragma warning disable CS8603 // Possible null reference argument.

        public string GetLocalizedString(string key)
        {
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public string GetLocalizedStringWithCulture(string key, CultureInfo culture)
        {
            _cultureInfo = culture;
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public CultureInfo SetCulture(string culture)
        {
            _cultureInfo = new CultureInfo(culture);
            SetReourceManager(_cultureInfo, assembly);
            return _cultureInfo;
        }
        public Assembly SetAssembly(Assembly assembly1)
        {
            return assembly = assembly1;
        }
        public ResourceManager SetReourceManager(CultureInfo resource, Assembly assembly1)
        {
            return _resourceManager = new ResourceManager("ACL.Resources." + resource.Name, assembly ?? assembly1);
        }
    }
}


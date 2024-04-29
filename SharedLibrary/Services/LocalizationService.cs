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
    public class LocalizationService : ILocalizationService
    {
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private Assembly _assembly;

        public LocalizationService(string baseName, Assembly assembly, string culture)
        {
            _assembly = assembly;
            _resourceManager = new ResourceManager(baseName, assembly);
            _cultureInfo = new CultureInfo(culture);
        }

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
            SetReourceManager(_cultureInfo, _assembly);
            return _cultureInfo;
        }
        public Assembly SetAssembly(Assembly assembly)
        {
            return _assembly = assembly;
        }
        public ResourceManager SetReourceManager(CultureInfo resource, Assembly assembly)
        {
            return _resourceManager = new ResourceManager("ACL.Resources." + resource.Name, _assembly ?? assembly);
        }
    }
}


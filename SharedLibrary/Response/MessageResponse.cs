using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Resources;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace SharedLibrary.Response
{
    public partial class BaseMessageResponse
    {
        public CultureInfo _cultureInfo;
        public ResourceManager _resourceManager;
        public LocalizationService localizationService;
        public Assembly _assembly;

        public string FetchMessage { get; set; }
        public string EditMessage { get; set; }
        public string CreateMessage { get; set; }
        public string DeleteMessage { get; set; }
        public string ExistMessage { get; set; }

        public BaseMessageResponse(string model, string language = "en-US")
        {
            _cultureInfo = new CultureInfo(language);
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources.en-US", _assembly, "en-US");
            try
            {
                FetchMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("fetchMessage", _cultureInfo);

                EditMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("editMessage", _cultureInfo);
                CreateMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("createMessage", _cultureInfo);
                DeleteMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("deleteMessage", _cultureInfo);
                ExistMessage = localizationService.GetLocalizedStringWithCulture("existMessage", _cultureInfo);
            }
            catch (Exception ex)
            {
                FetchMessage = model + " fetchMessage";
                EditMessage = model + " editMessage";
                CreateMessage = model + " createMessage";
                DeleteMessage = model + " deleteMessage";
                ExistMessage = model + " existMessage";
            }
        }

        public virtual string GetCreateMessage(string model = null, string language = null)
        {
            _cultureInfo = new CultureInfo("en-US");
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources.en-US", _assembly, "en-US");
            return CreateMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("createMessage", _cultureInfo);
        }
        public virtual string GetEditMessage(string model = null, string language = null)
        {
            _cultureInfo = new CultureInfo("en-US");
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources.en-US", _assembly, "en-US");
            return EditMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("editMessage", _cultureInfo);
        }
        public virtual string GetDeleteMessage(string model = null, string language = null)
        {
            _cultureInfo = new CultureInfo("en-US");
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources.en-US", _assembly, "en-US");
            return DeleteMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("deleteMessage", _cultureInfo);
        }
        public virtual string GetFetchMessage(string model = null, string language = null)
        {
            _cultureInfo = new CultureInfo("en-US");
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources.en-US", _assembly, "en-US");
            return FetchMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("fetchMessage", _cultureInfo);
        }
        public virtual string GetExistMessage(string model = null, string language = null)
        {
            _cultureInfo = new CultureInfo("en-US");
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources.en-US", _assembly, "en-US");
            return ExistMessage = localizationService.GetLocalizedStringWithCulture("existMessage", _cultureInfo);
        }
    }
}

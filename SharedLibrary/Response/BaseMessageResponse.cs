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
        public string NotFoundMessage { get; set; }
        public string CreateFail { get; set; }
        public string DeleteFail { get; set; }
        public string EditFail { get; set; }

        public string SomethingIsWrong { get; set; }

        public BaseMessageResponse(string model, string language = "en-US")
        {
            _cultureInfo = new CultureInfo(language);
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources."+language + _cultureInfo.Name, _assembly);
            localizationService = new LocalizationService("SharedLibrary.Resources."+language, _assembly, language);
      
                FetchMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("fetchMessage", _cultureInfo);

                EditMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("editMessage", _cultureInfo);
                CreateMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("createMessage", _cultureInfo);
                DeleteMessage = localizationService.GetLocalizedStringWithCulture(model, _cultureInfo) + " " + localizationService.GetLocalizedStringWithCulture("deleteMessage", _cultureInfo);
                ExistMessage = localizationService.GetLocalizedStringWithCulture("existMessage", _cultureInfo);
                NotFoundMessage = localizationService.GetLocalizedStringWithCulture("notFoundMessage", _cultureInfo);
                CreateFail = localizationService.GetLocalizedStringWithCulture("createFail", _cultureInfo);
                EditFail = localizationService.GetLocalizedStringWithCulture("deleteFail", _cultureInfo);
                DeleteFail = localizationService.GetLocalizedStringWithCulture("editFail", _cultureInfo);
                SomethingIsWrong = localizationService.GetLocalizedStringWithCulture("somethingIsWrong", _cultureInfo);
        }

    }
}

﻿using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Infrastructure.Services;
using System.Globalization;
using System.Reflection;

namespace SharedKernel.Main.Contracts.Common;

public static class Language
{

    public static string GetMessage(IHttpContextAccessor httpContextAccessor, string message)
    {
        var _assembly = Assembly.GetExecutingAssembly();
        var headers = httpContextAccessor.HttpContext.Request.Headers;
        // Check if the "Language" header exists and has a value
        var language = "en-US";
        if (headers.ContainsKey("Language"))
        {
            var lang = headers["Language"].ToString();
            var allowedLanguages = new List<string> { "en-US", "tr-TUR", "bn-BD" };
            if (allowedLanguages.Contains(lang))
            {
                language = lang;
            }
        }
        var localizationService = new LocalizationService("SharedKernel.Main.Infrastructure.Resources." + language, _assembly, language);
        var _cultureInfo = new CultureInfo(language);
        return localizationService.GetLocalizedStringWithCulture(message, _cultureInfo);
    }
}

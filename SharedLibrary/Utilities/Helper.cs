using SharedLibrary.Constants;
using SharedLibrary.Models;
using static SharedLibrary.Constants.Constants;

namespace SharedLibrary.Utilities
{
    public static class Helper
    {

        public static string GetLanguage(string inputLanguage, string currencyCode)
        {
            string language = "tr";

            if (!string.IsNullOrEmpty(inputLanguage) && Constants.Constants.SYSTEM_SUPPORTED_LANGUAGE.Contains(inputLanguage.ToLower()))
            {
                language = inputLanguage;
            }
            else
            {
                if (!string.IsNullOrEmpty(currencyCode))
                {
                    if (currencyCode == Models.Currency.TRY_CODE)
                    {
                        language = "tr";
                    }
                    else
                    {
                        language = "en";
                    }
                }
            }

            return language;
        }

        public static string __(string Text)
        {
            return Text;
        }
    }
}

namespace Admin.Web.Presentation.Routes
{
    public class CurrencyConversionRateRoutes
    {
        public const string GetCurrencyConversionRateMethod = "GET";
        public const string GetCurrencyConversionRateName = "currency-conversion-rates";
        public const string GetCurrencyConversionRateTemplate = "/currency-conversion-rates";

        public const string GetCurrencyConversionRateByIdMethod = "GET";
        public const string GetCurrencyConversionRateByIdName = "get-currency-conversion-rate-by-id";
        public const string GetCurrencyConversionRateByIdTemplate = "/currency-conversion-rates/{id}";

        public const string CreateCurrencyConversionRateMethod = "POST";
        public const string CreateCurrencyConversionRateName = "create-currency-conversion-rate";
        public const string CreateCurrencyConversionRateTemplate = "/currency-conversion-rates";

        public const string DeleteCurrencyConversionRateMethod = "DELETE";
        public const string DeleteCurrencyConversionRateName = "delete-currency-conversion-rate-by-id";
        public const string DeleteCurrencyConversionRateTemplate = "/currency-conversion-rates/{id}";

        public const string UpdateCurrencyConversionRateMethod = "PUT";
        public const string UpdateCurrencyConversionRateName = "update-currency-conversion-rate-by-id";
        public const string UpdateCurrencyConversionRateTemplate = "/currency-conversion-rates/{id}";
    }
}

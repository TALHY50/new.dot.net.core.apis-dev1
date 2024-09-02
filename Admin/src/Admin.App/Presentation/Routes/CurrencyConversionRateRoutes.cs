namespace Admin.App.Presentation.Routes
{
    public class CurrencyConversionRateRoutes
    {
        public const string GetCurrencyConversionRateMethod = "GET";
        public const string GetCurrencyConversionRateName = "currency_conversion_rates";
        public const string GetCurrencyConversionRateTemplate = "/currency_conversion_rates";

        public const string GetCurrencyConversionRateByIdMethod = "GET";
        public const string GetCurrencyConversionRateByIdName = "get_currency_conversion_rate_by_id";
        public const string GetCurrencyConversionRateByIdTemplate = "/currency_conversion_rates/{id}";

        public const string CreateCurrencyConversionRateMethod = "POST";
        public const string CreateCurrencyConversionRateName = "create_currency_conversion_rate";
        public const string CreateCurrencyConversionRateTemplate = "/currency_conversion_rates";

        public const string DeleteCurrencyConversionRateMethod = "DELETE";
        public const string DeleteCurrencyConversionRateName = "delete_currency_conversion_rate_by_id";
        public const string DeleteCurrencyConversionRateTemplate = "/currency_conversion_rates/{id}";

        public const string UpdateCurrencyConversionRateMethod = "PUT";
        public const string UpdateCurrencyConversionRateName = "update_currency_conversion_rate_by_id";
        public const string UpdateCurrencyConversionRateTemplate = "/currency_conversion_rates/{id}";
    }
}

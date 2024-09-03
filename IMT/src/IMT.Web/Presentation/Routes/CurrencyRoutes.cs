namespace IMT.App.Presentation.Routes
{
    public class CurrencyRoutes
    {
        public const string GetCurrencyMethod = "GET";
        public const string GetCurrencyName = "currencies";
        public const string GetCurrencyTemplate = "/v1/money-transfer/currencies";

        public const string GetCurrencyByIdMethod = "GET";
        public const string GetCurrencyByIdName = "get_currency_by_id";
        public const string GetCurrencyByIdTemplate = "/v1/money-transfer/currencies/{id}";

        public const string CreateCurrencyMethod = "POST";
        public const string CreateCurrencyName = "create_currency";
        public const string CreateCurrencyTemplate = "/v1/money-transfer/currencies";

        public const string DeleteCurrencyMethod = "DELETE";
        public const string DeleteCurrencyName = "delete_currency_by_id";
        public const string DeleteCurrencyTemplate = "/v1/money-transfer/currencies/{id}";

        public const string UpdateCurrencyMethod = "PUT";
        public const string UpdateCurrencyName = "update_currency_by_id";
        public const string UpdateCurrencyTemplate = "/v1/money-transfer/currencies/{id}";
    }
}

namespace Admin.App.Presentation.Routes
{
    public class CurrencyRoutes
    {
        public const string GetCurrencyMethod = "GET";
        public const string GetCurrencyName = "currencies";
        public const string GetCurrencyTemplate = "/currencies";

        public const string GetCurrencyByIdMethod = "GET";
        public const string GetCurrencyByIdName = "get_currency_by_id";
        public const string GetCurrencyByIdTemplate = "/currencies/{id}";

        public const string CreateCurrencyMethod = "POST";
        public const string CreateCurrencyName = "create_currency";
        public const string CreateCurrencyTemplate = "/currencies";

        public const string DeleteCurrencyMethod = "DELETE";
        public const string DeleteCurrencyName = "delete_currency_by_id";
        public const string DeleteCurrencyTemplate = "/currencies/{id}";

        public const string UpdateCurrencyMethod = "PUT";
        public const string UpdateCurrencyName = "update_currency_by_id";
        public const string UpdateCurrencyTemplate = "/currencies/{id}";
    }
}

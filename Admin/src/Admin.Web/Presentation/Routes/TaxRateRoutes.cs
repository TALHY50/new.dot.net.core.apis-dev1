namespace Admin.Web.Presentation.Routes
{
    public class TaxRateRoutes
    {
        public const string GetTaxRateMethod = "GET";
        public const string GetTaxRateName = "tax-rates";
        public const string GetTaxRateTemplate = "/tax-rates";

        public const string GetTaxRateByIdMethod = "GET";
        public const string GetTaxRateByIdName = "get-tax-rate-by-id";
        public const string GetTaxRateByIdTemplate = "/tax-rates/{id}";

        public const string CreateTaxRateMethod = "POST";
        public const string CreateTaxRateName = "create-tax-rate";
        public const string CreateTaxRateTemplate = "/tax-rates";

        public const string DeleteTaxRateMethod = "DELETE";
        public const string DeleteTaxRateName = "delete-tax-rate-by-id";
        public const string DeleteTaxRateTemplate = "/tax-rates/{id}";

        public const string UpdateTaxRateMethod = "PUT";
        public const string UpdateTaxRateName = "update-tax-rate-by-id";
        public const string UpdateTaxRateTemplate = "/tax-rates/{id}";
    }
}

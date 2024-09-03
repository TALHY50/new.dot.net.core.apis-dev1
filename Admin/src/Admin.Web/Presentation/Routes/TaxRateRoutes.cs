namespace Admin.Web.Presentation.Routes
{
    public class TaxRateRoutes
    {
        public const string GetTaxRateMethod = "GET";
        public const string GetTaxRateName = "tax_rates";
        public const string GetTaxRateTemplate = "/tax_rates";

        public const string GetTaxRateByIdMethod = "GET";
        public const string GetTaxRateByIdName = "get_tax_rate_by_id";
        public const string GetTaxRateByIdTemplate = "/tax_rates/{id}";

        public const string CreateTaxRateMethod = "POST";
        public const string CreateTaxRateName = "create_tax_rate";
        public const string CreateTaxRateTemplate = "/tax_rates";

        public const string DeleteTaxRateMethod = "DELETE";
        public const string DeleteTaxRateName = "delete_tax_rate_by_id";
        public const string DeleteTaxRateTemplate = "/tax_rates/{id}";

        public const string UpdateTaxRateMethod = "PUT";
        public const string UpdateTaxRateName = "update_tax_rates_by_id";
        public const string UpdateTaxRateTemplate = "/tax_rates/{id}";
    }
}

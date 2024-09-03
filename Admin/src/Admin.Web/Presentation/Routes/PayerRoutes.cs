namespace Admin.Web.Presentation.Routes
{
    public class PayerRoutes
    {
        public const string GetPayerMethod = "GET";
        public const string GetPayerName = "payers";
        public const string GetPayerTemplate = "/payers";

        public const string GetPayerByIdMethod = "GET";
        public const string GetPayerByIdName = "get_payer_by_id";
        public const string GetPayerByIdTemplate = "/payers/{id}";

        public const string CreatePayerMethod = "POST";
        public const string CreatePayerName = "create_payer";
        public const string CreatePayerTemplate = "/payers";

        public const string DeletePayerMethod = "DELETE";
        public const string DeletePayerName = "delete_payer_by_id";
        public const string DeletePayerTemplate = "/payers/{id}";

        public const string UpdatePayerMethod = "PUT";
        public const string UpdatePayerName = "update_payer_by_id";
        public const string UpdatePayerTemplate = "/payers/{id}";
    }
}

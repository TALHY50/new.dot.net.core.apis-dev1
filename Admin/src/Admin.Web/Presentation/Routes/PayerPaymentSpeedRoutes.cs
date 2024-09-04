namespace Admin.Web.Presentation.Routes
{
    public class PayerPaymentSpeedRoutes
    {
        public const string GetPayerPaymentSpeedMethod = "GET";
        public const string GetPayerPaymentSpeedName = "payer_payment_speeds";
        public const string GetPayerPaymentSpeedTemplate = "/payer_payment_speeds";

        public const string GetPayerPaymentSpeedByIdMethod = "GET";
        public const string GetPayerPaymentSpeedByIdName = "get_payer_payment_speeds_by_id";
        public const string GetPayerPaymentSpeedByIdTemplate = "/payer_payment_speeds/{id}";

        public const string CreatePayerPaymentSpeedMethod = "POST";
        public const string CreatePayerPaymentSpeedName = "create_payer_payment_speeds";
        public const string CreatePayerPaymentSpeedTemplate = "/payer_payment_speeds";

        public const string DeletePayerPaymentSpeedMethod = "DELETE";
        public const string DeletePayerPaymentSpeedName = "delete_payer_payment_speeds_by_id";
        public const string DeletePayerPaymentSpeedTemplate = "/payer_payment_speeds/{id}";

        public const string UpdatePayerPaymentSpeedMethod = "PUT";
        public const string UpdatePayerPaymentSpeedName = "update_payer_payment_speeds_by_id";
        public const string UpdatePayerPaymentSpeedTemplate = "/payer_payment_speeds/{id}";
    }
}

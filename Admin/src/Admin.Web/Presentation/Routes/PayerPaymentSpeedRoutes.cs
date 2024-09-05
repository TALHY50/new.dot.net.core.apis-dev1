namespace Admin.Web.Presentation.Routes
{
    public class PayerPaymentSpeedRoutes
    {
        public const string GetPayerPaymentSpeedMethod = "GET";
        public const string GetPayerPaymentSpeedName = "payer-payment-speeds";
        public const string GetPayerPaymentSpeedTemplate = "/payer-payment-speeds";

        public const string GetPayerPaymentSpeedByIdMethod = "GET";
        public const string GetPayerPaymentSpeedByIdName = "get-payer-payment-speed-by-id";
        public const string GetPayerPaymentSpeedByIdTemplate = "/payer-payment-speeds/{id}";

        public const string CreatePayerPaymentSpeedMethod = "POST";
        public const string CreatePayerPaymentSpeedName = "create-payer-payment-speed";
        public const string CreatePayerPaymentSpeedTemplate = "/payer-payment-speeds";

        public const string DeletePayerPaymentSpeedMethod = "DELETE";
        public const string DeletePayerPaymentSpeedName = "delete-payer-payment-speed-by-id";
        public const string DeletePayerPaymentSpeedTemplate = "/payer-payment-speeds/{id}";

        public const string UpdatePayerPaymentSpeedMethod = "PUT";
        public const string UpdatePayerPaymentSpeedName = "update-payer-payment-speed-by-id";
        public const string UpdatePayerPaymentSpeedTemplate = "/payer-payment-speeds/{id}";
    }
}

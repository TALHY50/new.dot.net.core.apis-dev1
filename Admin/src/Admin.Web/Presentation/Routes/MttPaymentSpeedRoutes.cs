namespace Admin.Web.Presentation.Routes
{
    public class MttPaymentSpeedRoutes
    {
        public const string GetMttPaymentSpeedMethod = "GET";
        public const string GetMttPaymentSpeedName = "mtt-payment-speeds";
        public const string GetMttPaymentSpeedTemplate = "/mtt-payment-speeds";

        public const string GetMttPaymentSpeedByIdMethod = "GET";
        public const string GetMttPaymentSpeedByIdName = "get_mtt-payment-speed_by_id";
        public const string GetMttPaymentSpeedByIdTemplate = "/mtt-payment-speeds/{id}";

        public const string CreateMttPaymentSpeedMethod = "POST";
        public const string CreateMttPaymentSpeedName = "create_mtt-payment-speed";
        public const string CreateMttPaymentSpeedTemplate = "/mtt-payment-speeds";

        public const string DeleteMttPaymentSpeedMethod = "DELETE";
        public const string DeleteMttPaymentSpeedName = "delete_mtt-payment-speed_by_id";
        public const string DeleteMttPaymentSpeedTemplate = "/mtt-payment-speeds/{id}";

        public const string UpdateMttPaymentSpeedMethod = "PUT";
        public const string UpdateMttPaymentSpeedName = "update_mtt-payment-speed_by_id";
        public const string UpdateMttPaymentSpeedTemplate = "/mtt-payment-speeds/{id}";
    }
}

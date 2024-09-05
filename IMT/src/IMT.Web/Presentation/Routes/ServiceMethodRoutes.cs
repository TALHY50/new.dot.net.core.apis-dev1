namespace IMT.App.Presentation.Routes
{
    public class ServiceMethodRoutes
    {
        public const string GetServiceMethodMethod = "GET";
        public const string GetServiceMethodName = "service_methods";
        public const string GetServiceMethodTemplate = "/money-transfer/service-methods";

        public const string GetServiceMethodByIdMethod = "GET";
        public const string GetServiceMethodByIdName = "get_service_methods_by_id";
        public const string GetServiceMethodByIdTemplate = "/money-transfer/service-methods/{id}";

        public const string CreateServiceMethodMethod = "POST";
        public const string CreateServiceMethodName = "create_service_methods";
        public const string CreateServiceMethodTemplate = "/money-transfer/service-methods";

        public const string DeleteServiceMethodMethod = "DELETE";
        public const string DeleteServiceMethodName = "delete_service_methods_by_id";
        public const string DeleteServiceMethodTemplate = "/money-transfer/service-methods/{id}";

        public const string UpdateServiceMethodMethod = "PUT";
        public const string UpdateServiceMethodName = "update_service_methods_by_id";
        public const string UpdateServiceMethodTemplate = "/money-transfer/service-methods/{id}";
    }
}

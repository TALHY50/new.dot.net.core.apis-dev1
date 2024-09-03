namespace Admin.App.Presentation.Routes
{
    public class ServiceMethodRoutes
    {
        public const string GetServiceMethodMethod = "GET";
        public const string GetServiceMethodName = "service_methods";
        public const string GetServiceMethodTemplate = "/service_methods";

        public const string GetServiceMethodByIdMethod = "GET";
        public const string GetServiceMethodByIdName = "get_service_methods_by_id";
        public const string GetServiceMethodByIdTemplate = "/service_methods/{id}";

        public const string CreateServiceMethodMethod = "POST";
        public const string CreateServiceMethodName = "create_service_methods";
        public const string CreateServiceMethodTemplate = "/service_methods";

        public const string DeleteServiceMethodMethod = "DELETE";
        public const string DeleteServiceMethodName = "delete_service_methods_by_id";
        public const string DeleteServiceMethodTemplate = "/service_methods/{id}";

        public const string UpdateServiceMethodMethod = "PUT";
        public const string UpdateServiceMethodName = "update_service_methods_by_id";
        public const string UpdateServiceMethodTemplate = "/service_methods/{id}";
    }
}

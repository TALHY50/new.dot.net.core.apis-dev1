namespace Admin.Web.Presentation.Routes
{
    public class ServiceMethodRoutes
    {
        public const string GetServiceMethodMethod = "GET";
        public const string GetServiceMethodName = "service-methods";
        public const string GetServiceMethodTemplate = "/service-methods";

        public const string GetServiceMethodByIdMethod = "GET";
        public const string GetServiceMethodByIdName = "get-service-method-by-id";
        public const string GetServiceMethodByIdTemplate = "/service-methods/{id}";

        public const string CreateServiceMethodMethod = "POST";
        public const string CreateServiceMethodName = "create-service-method";
        public const string CreateServiceMethodTemplate = "/service-methods";

        public const string DeleteServiceMethodMethod = "DELETE";
        public const string DeleteServiceMethodName = "delete-service-method-by-id";
        public const string DeleteServiceMethodTemplate = "/service-methods/{id}";

        public const string UpdateServiceMethodMethod = "PUT";
        public const string UpdateServiceMethodName = "update-service-method-by-id";
        public const string UpdateServiceMethodTemplate = "/service-methods/{id}";
    }
}

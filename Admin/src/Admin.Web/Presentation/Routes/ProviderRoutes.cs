namespace Admin.Web.Presentation.Routes
{
    public class ProviderRoutes
    {
        public const string GetProviderMethod = "GET";
        public const string GetProviderName = "providers";
        public const string GetProviderTemplate = "/providers";

        public const string GetProviderByIdMethod = "GET";
        public const string GetProviderByIdName = "get_provider_by_id";
        public const string GetProviderByIdTemplate = "/providers/{id}";

        public const string CreateProviderMethod = "POST";
        public const string CreateProviderName = "create_providerr";
        public const string CreateProviderTemplate = "/providers";

        public const string DeleteProviderMethod = "DELETE";
        public const string DeleteProviderName = "delete_provider_by_id";
        public const string DeleteProviderTemplate = "/providers/{id}";

        public const string UpdateProviderMethod = "PUT";
        public const string UpdateProviderName = "update_provider_by_id";
        public const string UpdateProviderTemplate = "/providers/{id}";
    }
}

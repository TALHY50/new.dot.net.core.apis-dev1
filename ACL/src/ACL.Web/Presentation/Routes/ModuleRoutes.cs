namespace ACL.Web.Presentation.Routes
{
    public class ModuleRoutes
    {
        public const string GetModuleMethod = "GET";
        public const string GetModuleName = "modules";
        public const string GetModuleTemplate = "/modules";

        public const string GetModuleByIdMethod = "GET";
        public const string GetModuleByIdName = "get_module_by_id";
        public const string GetModuleByIdTemplate = "/modules/{id}";

        public const string CreateModuleMethod = "POST";
        public const string CreateModuleName = "create_module";
        public const string CreateModuleTemplate = "/modules";

        public const string DeleteModuleMethod = "DELETE";
        public const string DeleteModuleName = "delete_module_by_id";
        public const string DeleteModuleTemplate = "/modules/{id}";

        public const string UpdateModuleMethod = "PUT";
        public const string UpdateModuleName = "update_module_by_id";
        public const string UpdateModuleTemplate = "/modules";
    }
}

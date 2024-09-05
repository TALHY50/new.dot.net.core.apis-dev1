namespace ACL.Web.Presentation.Routes
{
    public class SubModuleRoutes
    {
        public const string GetSubModuleMethod = "GET";
        public const string GetSubModuleName = "submodules";
        public const string GetSubModuleTemplate = "/submodules";

        public const string GetSubModuleByIdMethod = "GET";
        public const string GetSubModuleByIdName = "get_submodule_by_id";
        public const string GetSubModuleByIdTemplate = "/submodules/{id}";

        public const string CreateSubModuleMethod = "POST";
        public const string CreateSubModuleName = "create_submodule";
        public const string CreateSubModuleTemplate = "/submodules";

        public const string DeleteSubModuleMethod = "DELETE";
        public const string DeleteSubModuleName = "delete_submodule_by_id";
        public const string DeleteSubModuleTemplate = "/submodules/{id}";

        public const string UpdateSubModuleMethod = "PUT";
        public const string UpdateSubModuleName = "update_submodule_by_id";
        public const string UpdateSubModuleTemplate = "/submodules/{id}";
    }
}

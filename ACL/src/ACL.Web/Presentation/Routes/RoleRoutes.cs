namespace ACL.Web.Presentation.Routes
{
    public class RoleRoutes
    {
        public const string Base = "api/v1/";

        public const string GetRoleMethod = "GET";
        public const string GetRoleName = "roles";
        public const string GetRoleTemplate = "/roles";

        public const string GetRoleByIdMethod = "GET";
        public const string GetRoleByIdName = "get_role_by_id";
        public const string GetRoleByIdTemplate = "/roles/{id}";

        public const string CreateRoleMethod = "POST";
        public const string CreateRoleName = "create_role";
        public const string CreateRoleTemplate = "/roles";

        public const string DeleteRoleMethod = "DELETE";
        public const string DeleteRoleName = "delete_role_by_id";
        public const string DeleteRoleTemplate = "/roles/{id}";

        public const string UpdateRoleMethod = "PUT";
        public const string UpdateRoleName = "update_role_by_id";
        public const string UpdateRoleTemplate = "/roles/{id}";
    }
}

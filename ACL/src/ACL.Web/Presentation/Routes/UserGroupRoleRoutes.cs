namespace ACL.Web.Presentation.Routes
{
    public class UserGroupRoleRoutes
    {
        public const string GetUserGroupRoleMethod = "GET";
        public const string GetUserGroupRoleName = "user_group_roles";
        public const string GetUserGroupRoleTemplate = "/user_group_roles";

        public const string GetUserGroupRoleByUserGroupIdMethod = "GET";
        public const string GetUserGroupRoleByUserGroupIdName = "get_user_group_role_by_user_group_id";
        public const string GetUserGroupRoleByUserGroupIdTemplate = "/user_group_roles/{user_group_id}";

        public const string CreateUserGroupRoleMethod = "POST";
        public const string CreateUserGroupRoleName = "create_user_group_role";
        public const string CreateUserGroupRoleTemplate = "/user_group_roles";

        public const string DeleteUserGroupRoleMethod = "DELETE";
        public const string DeleteUserGroupRoleName = "delete_user_group_role_by_id";
        public const string DeleteUserGroupRoleTemplate = "/user_group_roles/{id}";

        public const string UpdateUserGroupRoleMethod = "PUT";
        public const string UpdateUserGroupRoleName = "update_user_group_roles";
        public const string UpdateUserGroupRoleTemplate = "/user_group_roles";
    }
}

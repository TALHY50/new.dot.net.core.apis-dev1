namespace ACL.Web.Presentation.Routes
{
    public class UserGroupRoleRoutes
    {
        //public const string GetUserGroupRoleMethod = "GET";
        //public const string GetUserGroupRoleName = "user-group-roles";
        //public const string GetUserGroupRoleTemplate = "/user-group-roles";

        public const string GetUserGroupRoleByUserGroupIdMethod = "GET";
        public const string GetUserGroupRoleByUserGroupIdName = "get_usergroup_role_by_user_group_id";
        public const string GetUserGroupRoleByUserGroupIdTemplate = "/usergroups/roles/{user_group_id}";

        //public const string CreateUserGroupRoleMethod = "POST";
        //public const string CreateUserGroupRoleName = "create-user-group-role";
        //public const string CreateUserGroupRoleTemplate = "/user-group-roles";

        //public const string DeleteUserGroupRoleMethod = "DELETE";
        //public const string DeleteUserGroupRoleName = "delete-user-group-role-by-id";
        //public const string DeleteUserGroupRoleTemplate = "/user-group-roles/{id}";

        public const string UpdateUserGroupRoleMethod = "PUT";
        public const string UpdateUserGroupRoleName = "update_usergroup_role";
        public const string UpdateUserGroupRoleTemplate = "/usergroups/roles";
    }
}

namespace ACL.Web.Presentation.Routes
{
    public class ACLUserGroupRoutes
    {
        public const string GetACLUserGroupMethod = "GET";
        public const string GetACLUserGroupName = "acl-user-groups";
        public const string GetACLUserGroupTemplate = "/acl-user-groups";

        public const string GetACLUserGroupByRoleIdMethod = "GET";
        public const string GetACLUserGroupByRoleIdName = "get_acl-user-group_by_id";
        public const string GetACLUserGroupByRoleIdTemplate = "/acl-user-groups/{id}";

        public const string CreateACLUserGroupMethod = "POST";
        public const string CreateACLUserGroupName = "create_acl-user-group";
        public const string CreateACLUserGroupTemplate = "/acl-user-groups";

        public const string DeleteACLUserGroupMethod = "DELETE";
        public const string DeleteACLUserGroupName = "delete_acl-user-group_by_id";
        public const string DeleteACLUserGroupTemplate = "/acl-user-groups/{id}";

        public const string UpdateACLUserGroupMethod = "PUT";
        public const string UpdateACLUserGroupName = "update_acl-user-group_by_id";
        public const string UpdateACLUserGroupTemplate = "/acl-user-groups";
    }
}

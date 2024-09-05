namespace ACL.Web.Presentation.Routes
{
    public class ACLUserGroupRoutes
    {
        public const string GetACLUserGroupMethod = "GET";
        public const string GetACLUserGroupName = "user-groups";
        public const string GetACLUserGroupTemplate = "/user-groups";

        public const string GetACLUserGroupByIdMethod = "GET";
        public const string GetACLUserGroupByIdName = "get_acl-user-group_by_id";
        public const string GetACLUserGroupByIdTemplate = "/user-groups/{id}";

        public const string CreateACLUserGroupMethod = "POST";
        public const string CreateACLUserGroupName = "create_acl-user-group";
        public const string CreateACLUserGroupTemplate = "/user-groups";

        public const string DeleteACLUserGroupMethod = "DELETE";
        public const string DeleteACLUserGroupName = "delete_acl-user-group_by_id";
        public const string DeleteACLUserGroupTemplate = "/user-groups/{id}";

        public const string UpdateACLUserGroupMethod = "PUT";
        public const string UpdateACLUserGroupName = "update_acl-user-group_by_id";
        public const string UpdateACLUserGroupTemplate = "/user-groups/{id}";
    }
}

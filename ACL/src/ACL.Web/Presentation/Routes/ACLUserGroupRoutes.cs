namespace ACL.Web.Presentation.Routes
{
    public class ACLUserGroupRoutes
    {
        public const string GetACLUserGroupMethod = "GET";
        public const string GetACLUserGroupName = "usergroups";
        public const string GetACLUserGroupTemplate = "/usergroups";

        public const string GetACLUserGroupByIdMethod = "GET";
        public const string GetACLUserGroupByIdName = "get_usergroup_by_id";
        public const string GetACLUserGroupByIdTemplate = "/usergroups/{id}";

        public const string CreateACLUserGroupMethod = "POST";
        public const string CreateACLUserGroupName = "create_usergroup";
        public const string CreateACLUserGroupTemplate = "/usergroups";

        public const string DeleteACLUserGroupMethod = "DELETE";
        public const string DeleteACLUserGroupName = "delete_usergroup_by_id";
        public const string DeleteACLUserGroupTemplate = "/usergroups/{id}";

        public const string UpdateACLUserGroupMethod = "PUT";
        public const string UpdateACLUserGroupName = "update_usergroup_by_id";
        public const string UpdateACLUserGroupTemplate = "/usergroups/{id}";
    }
}

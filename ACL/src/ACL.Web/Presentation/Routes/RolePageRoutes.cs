namespace ACL.Web.Presentation.Routes;

public class RolePageRoutes
{
    public const string GetRolePageMethod = "GET";
    public const string GetRolePageName = "role_pages";
    public const string GetRolePageTemplate = "/role-pages";

    public const string GetRolePageByRoleIdMethod = "GET";
    public const string GetRolePageByRoleIdName = "get_role_page_by_role_id";
    public const string GetRolePageByRoleIdTemplate = "/role-pages/{role_id}";

    public const string CreateRolePageMethod = "POST";
    public const string CreateRolePageName = "create_role_page";
    public const string CreateRolePageTemplate = "/role-pages";

    public const string DeleteRolePageMethod = "DELETE";
    public const string DeleteRolePageName = "delete_role_page_by_id";
    public const string DeleteRolePageTemplate = "/role-pages/{id}";

    public const string UpdateRolePageMethod = "PUT";
    public const string UpdateRolePageName = "update_role_page_by_id";
    public const string UpdateRolePageTemplate = "/role-pages";
}

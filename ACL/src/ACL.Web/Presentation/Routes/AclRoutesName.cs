namespace ACL.Web.Presentation.Routes;

public static class AclRoutesName
{


    public static class AclAuthRouteNames
    {
        public const string Login = "acl.auth.login";
        public const string SignOut = "acl.auth.signout";
        public const string RefreshToken = "acl.auth.refreshToken";
        public const string CreateUser = "acl.auth.createUser";
    }

    public static class AclWeatherForecastRouteNames
    {
        public const string GetWeatherForecasts = "acl.weatherForecast.getWeatherForecasts";
    }

    public static class AclCompanyRouteNames
    {
        public const string List = "acl.company.list";
        public const string Add = "acl.company.add";
        public const string View = "acl.company.show";
        public const string Edit = "acl.company.edit";
        public const string Destroy = "acl.company.destroy";
    }
    public static class AclBranchRouteNames
    {
        public const string List = "acl.branch.list";
        public const string Add = "acl.branch.add";
        public const string View = "acl.branch.show";
        public const string Edit = "acl.branch.edit";
        public const string Destroy = "acl.branch.destroy";
    }

    public static class AclCompanyModuleRouteNames
    {
        public const string List = "acl.company_module.list";
        public const string Add = "acl.company_module.add";
        public const string View = "acl.company_module.view";
        public const string Edit = "acl.company_module.edit";
        public const string Destroy = "acl.company_module.destroy";
    }
    public static class AclModuleRouteNames
    {
        public const string List = "acl.module.list";
        public const string Add = "acl.module.add";
        public const string View = "acl.module.view";
        public const string Edit = "acl.module.edit";
        public const string Destroy = "acl.module.destroy";
    }
    public static class AclSubmoduleRouteNames
    {
        public const string List = "acl.submodule.list";
        public const string Add = "acl.submodule.add";
        public const string View = "acl.submodule.view";
        public const string Edit = "acl.submodule.edit";
        public const string Destroy = "acl.submodule.destroy";

    }
    public static class AclRoleRouteNames
    {
        public const string List = "acl.role.list";
        public const string Add = "acl.role.add";
        public const string View = "acl.role.view";
        public const string Edit = "acl.role.edit";
        public const string Destroy = "acl.role.destroy";

    }
    public static class AclRolePageRouteNames
    {
        public const string List = "acl.role&page.association";
        public const string Edit = "acl.role&page.association.update";
    }

    public static class AclPageNamesRouteNames
    {
        public const string Base = "acl.page.";
        public const string List = Base + "list";
        public const string Add = Base + "add";
        public const string View = Base + "view";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }
    public static class AclPageRouteRouteNames
    {
        public const string Base = "acl.page.route.";
        public const string Add = Base + "add";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }

    public static class AclUserRouteNames
    {
        public const string Base = "acl.user.";
        public const string List = Base + "list";
        public const string Add = Base + "add";
        public const string View = Base + "view";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }

    public class AclUserGroupRoleRouteNames
    {
        public const string ModelName = "acl.usergroups.";
        public const string List = ModelName + "role.association";
        public const string Update = ModelName + "role.association.update";
    }
    public class AclUserGroupRouteNames
    {
        public const string ModelName = "acl.usergroups.";
        public const string List = ModelName + "list";
        public const string Add = ModelName + "add";
        public const string View = ModelName + "view";
        public const string Edit = ModelName + "edit";
        public const string Destroy = ModelName + "destroy";
    }

    public class AclPasswordRouteNames
    {
        public const string Reset = "acl.reset.password";
        public const string Forget = "acl.forget.password";
        public const string VerifyToken = "acl.verify.token.and.update.password";

    }
    public static class AclStateRouteNames
    {
        public const string Base = "acl.state.";
        public const string List = Base + "list";
        public const string Add = Base + "add";
        public const string View = Base + "view";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }

    public class AclCountryRouteNames
    {
        public const string ModelName = "acl.countries.";
        public const string List = ModelName + "list";
        public const string Add = ModelName + "add";
        public const string View = ModelName + "view";
        public const string Edit = ModelName + "edit";
        public const string Destroy = ModelName + "destroy";
    }




}
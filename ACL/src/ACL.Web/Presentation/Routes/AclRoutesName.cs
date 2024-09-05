namespace ACL.Web.Presentation.Routes;

public static class AclRoutesName
{


    public static class AclAuthRouteNames
    {
        public const string Login = "auth.login";
        public const string SignOut = "auth.signout";
        public const string RefreshToken = "auth.refreshToken";
        public const string CreateUser = "auth.createUser";
    }

    public static class AclWeatherForecastRouteNames
    {
        public const string GetWeatherForecasts = "weatherForecast.getWeatherForecasts";
    }

    public static class AclCompanyRouteNames
    {
        public const string List = "company.list";
        public const string Add = "company.add";
        public const string View = "company.show";
        public const string Edit = "company.edit";
        public const string Destroy = "company.destroy";
    }
    public static class AclBranchRouteNames
    {
        public const string List = "branch.list";
        public const string Add = "branch.add";
        public const string View = "branch.show";
        public const string Edit = "branch.edit";
        public const string Destroy = "branch.destroy";
    }

    public static class AclCompanyModuleRouteNames
    {
        public const string List = "company_module.list";
        public const string Add = "company_module.add";
        public const string View = "company_module.view";
        public const string Edit = "company_module.edit";
        public const string Destroy = "company_module.destroy";
    }
    public static class AclModuleRouteNames
    {
        public const string List = "module.list";
        public const string Add = "module.add";
        public const string View = "module.view";
        public const string Edit = "module.edit";
        public const string Destroy = "module.destroy";
    }
    public static class AclSubmoduleRouteNames
    {
        public const string List = "submodule.list";
        public const string Add = "submodule.add";
        public const string View = "submodule.view";
        public const string Edit = "submodule.edit";
        public const string Destroy = "submodule.destroy";

    }
    public static class AclRoleRouteNames
    {
        public const string List = "role.list";
        public const string Add = "role.add";
        public const string View = "role.view";
        public const string Edit = "role.edit";
        public const string Destroy = "role.destroy";

    }
    public static class AclRolePageRouteNames
    {
        public const string List = "role&page.association";
        public const string Edit = "role&page.association.update";
    }

    public static class AclPageNamesRouteNames
    {
        public const string Base = "page.";
        public const string List = Base + "list";
        public const string Add = Base + "add";
        public const string View = Base + "view";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }
    public static class AclPageRouteRouteNames
    {
        public const string Base = "page.route.";
        public const string Add = Base + "add";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }

    public static class AclUserRouteNames
    {
        public const string Base = "user.";
        public const string List = Base + "list";
        public const string Add = Base + "add";
        public const string View = Base + "view";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }

    public class AclUserGroupRoleRouteNames
    {
        public const string ModelName = "usergroups.";
        public const string List = ModelName + "role.association";
        public const string Update = ModelName + "role.association.update";
    }
    public class AclUserGroupRouteNames
    {
        public const string ModelName = "usergroups.";
        public const string List = ModelName + "list";
        public const string Add = ModelName + "add";
        public const string View = ModelName + "view";
        public const string Edit = ModelName + "edit";
        public const string Destroy = ModelName + "destroy";
    }

    public class AclPasswordRouteNames
    {
        public const string Reset = "reset.password";
        public const string Forget = "forget.password";
        public const string VerifyToken = "verify.token.and.update.password";

    }
    public static class AclStateRouteNames
    {
        public const string Base = "state.";
        public const string List = Base + "list";
        public const string Add = Base + "add";
        public const string View = Base + "view";
        public const string Edit = Base + "edit";
        public const string Destroy = Base + "destroy";
    }

    public class AclCountryRouteNames
    {
        public const string ModelName = "countries.";
        public const string List = ModelName + "list";
        public const string Add = ModelName + "add";
        public const string View = ModelName + "view";
        public const string Edit = ModelName + "edit";
        public const string Destroy = ModelName + "destroy";
    }




}
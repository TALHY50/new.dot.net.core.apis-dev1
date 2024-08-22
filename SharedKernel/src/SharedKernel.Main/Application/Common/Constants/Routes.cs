namespace SharedKernel.Main.Application.Common.Constants
{
    public class AclRoutesUrl
    {
        public const string Base = "api/v1/";
        
        public class AclAuthRouteUrl
        {
            public const string Base = "api/v1/";
            public const string Login = Base + "login";
        }

        public class WeatherForecastRouteUrl
        {
            public const string GetWeatherForecast = "api/v1/GetWeatherForecast";
        }
        


        public class AclModuleRouteUrl
        {
            public const string List = Base + "modules";
            public const string Add = Base + "modules/add";
            public const string Edit = Base + "modules/edit";
            public const string View = Base + "modules/view/{id}";
            public const string Destroy = Base + "modules/delete/{id}";
        }
        public class AclCompanyRouteUrl
        {
            public const string ModelName = Base + "companies";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclBranchRouteUrl
        {
            public const string ModelName = Base + "branches";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclCompanyModuleRouteUrl
        {
            public const string ModelName = Base + "company/modules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclRolePageRouteUrl
        {
            public const string ModelName = Base + "roles/pages";
            public const string List = ModelName + "/{id}";
            public const string Edit = ModelName + "/update";
        }
        public class AclPageRouteUrl
        {
            public const string ModelName = Base + "pages";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclPageRouteRouteUrl
        {
            public const string ModelName = Base + "page/routes";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclSubmoduleRouteUrl
        {
            public const string ModelName = Base + "submodules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclRoleRouteUrl
        {
            public const string ModelName = Base + "roles";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclUserGroupRoleRouteUrl
        {
            public const string ModelName = Base + "usergroups/roles";
            public const string List = ModelName + "/{userGroupId}";
            public const string Update = ModelName + "/update";
        }

        public class AclUserRouteUrl
        {
            public const string ModelName = Base + "users";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclUserGroupRouteUrl
        {
            public const string ModelName = Base + "usergroups";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string View = ModelName + "/view/{id}";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/destroy/{id}";
        }
        public class AclPasswordRouteUrl
        {
            public const string ModelName = Base + "password";
            public const string Reset = ModelName + "/reset";
            public const string Forget = ModelName + "/forget";
            public const string VerifyToken = ModelName + "/forget/verify";

        }
        public class AclStateRouteUrl
        {
            public const string ModelName = Base + "states";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string View = ModelName + "/view/{id}";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/delete/{id}";

        }

        public class AclCountryRouteUrl
        {
            public const string ModelName = Base + "countries";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }

    }
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

    public class Routes
    {
        public const string CreateEmailEventRouteName = "create-email-event";
        public const string CreateEmailEventRoute = "/api/notification/event/email/create";

    }
    
    
}

namespace ACL.Web.Presentation.Routes;

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
namespace ADMIN.Application.Infrastructure.Route
{

    public class AdminRoutesUrl
    {
        public class AdminProviderUrl
        {
            public const string List = "api/v1/provider/list";
            public const string Add = "api/v1/provider/add";
            public const string Edit = "api/v1/provider/edit/{id}";
            public const string Find = "api/v1/provider/{id}";
            public const string Delete = "api/v1/provider/delete/{id}";
        }

        public class AdminRegionsUrl
        {
            public const string List = "api/v1/regions/list";
            public const string Add = "api/v1/regions/add";
            public const string Edit = "api/v1/regions/edit/{id}";
            public const string Find = "api/v1/regions/{id}";
            public const string Delete = "api/v1/regions/delete/{id}";
        }
    }
    public class AdminRoutesNames
    {
        public class AdminProviderNames
        {
            public const string List = "admin.provider.list";
            public const string Add = "admin.provider.add";
            public const string Edit = "admin.provider.edit";
            public const string Find = "admin.provider.find";
            public const string Delete = "admin.provider.delete";
        }

        public class AdminRegionsNames
        {
            public const string List = "admin.regions.list";
            public const string Add = "admin.regions.add";
            public const string Edit = "admin.regions.edit";
            public const string Find = "admin.regions.find";
            public const string Delete = "admin.regions.delete";
        }
    }
}
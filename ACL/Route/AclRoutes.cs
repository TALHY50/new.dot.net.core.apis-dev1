using Google.Protobuf.WellKnownTypes;
using SharedLibrary.Models;
using System.Reflection.Metadata;

namespace ACL.Route
{
    public class AclRoutesUrl
    {
        public const string Base = "api/v1/";
        public class AclModule
        {
            public const string List = Base + "modules";
            public const string Add = Base + "modules/add";
            public const string Edit = Base + "modules/edit/{Id}";
            public const string View = Base + "modules/view/{Id}";
            public const string Destroy = Base + "modules/delete/{Id}";
        }
        public class AclSubModule
        {
            public const string ModelName = Base + "submodules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{Id}";
            public const string View = ModelName + "/view/{Id}";
            public const string Destroy = ModelName + "/delete/{Id}";
        }
        public class AclCompanyModule
        {
            public const string ModelName = Base + "company/modules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{Id}";
            public const string View = ModelName + "/view/{Id}";
            public const string Destroy = ModelName + "/delete/{Id}";
        }
        public class AclPage
        {
            public const string ModelName = Base + "pages";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclPageRoute
        {
            public const string ModelName = Base + "page/routes";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }

        public class AclUser
        {
            public const string ModelName = Base + "users";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }



    }
    public static class AclRoutesName
    {
        public static class SubmoduleRouteNames
        {
            public const string list = "acl.submodule.list";
            public const string add = "acl.submodule.add";
            public const string view = "acl.submodule.view";
            public const string edit = "acl.submodule.edit";
            public const string destroy = "acl.submodule.destroy";
        }

        public static class AclPageNames
        {
            public const string Base = "acl.page.";
            public const string List = Base + "list";
            public const string Add = Base + "add";
            public const string View = Base + "view";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }
        public static class AclPageRouteNames
        {
            public const string Base = "acl.page.route.";
            public const string Add = Base + "add";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }

        public static class AclUserNames
        {
            public const string Base = "acl.user.";
            public const string List = Base + "list";
            public const string Add = Base + "add";
            public const string View = Base + "view";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }


    }
}

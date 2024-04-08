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
            public const string ModelName =Base + "submodules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{Id}";
            public const string View = ModelName + "/view/{Id}";
            public const string Destroy = ModelName + "/delete/{Id}";
        }
        public class AclCompanyModule
        {
            public const string ModelName = Base +"company/modules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{Id}";
            public const string View = ModelName + "/view/{Id}";
            public const string Destroy = ModelName + "/delete/{Id}";
        }


    }
    public static class AclRoutesName
    {
        public static class SubmoduleRouteNames
        {
            public const string List = "acl.submodule.list";
            public const string Add = "acl.submodule.add";
            public const string View = "acl.submodule.view";
            public const string Edit = "acl.submodule.edit";
            public const string Destroy = "acl.submodule.destroy";
        }
    }
}

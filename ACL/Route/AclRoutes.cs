using Google.Protobuf.WellKnownTypes;
using SharedLibrary.Models;
using System.Reflection.Metadata;

namespace ACL.Route
{
    public class AclRoutesUrl
    {
        public class AclCompanyModule
        {
            public const string modelname = "api/v1/company/modules";
            public const string List = modelname;
            public const string Add = modelname + "/add";
            public const string Edit = modelname + "/edit/{Id}";
            public const string View = modelname + "/view/{Id}";
            public const string Destroy = modelname + "/delete/{Id}";
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
    }
}

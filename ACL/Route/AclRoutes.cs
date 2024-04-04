using Google.Protobuf.WellKnownTypes;
using SharedLibrary.Models;
using System.Reflection.Metadata;

namespace ACL.Route
{
    public class AclRoutesUrl
    {
        public const string Root = "api/v1";
        public class AclCompanyModule
        {
            public const string modelname = "api/v1/company/modules";
            public const string List = modelname;
            public const string Add = modelname + "/add";
            public const string Edit = modelname + "/edit/{Id}";
            public const string View = modelname + "/view/{Id}";
            public const string Destroy = modelname + "/delete/{Id}";
        }
        public class AclSubmodule
        {
            public const string modelname = "submodules";
            public const string List = modelname;
            public const string Add = modelname + "/add";
            public const string Edit = modelname + "/edit/{id}";
            public const string View = modelname + "/view/{id}";
            public const string Destroy = modelname + "/delete/{id}";
        }
        public class AclRole
        {
            public const string modelname = "roles";
            public const string List = modelname;
            public const string Add = modelname + "/add";
            public const string Edit = modelname + "/edit/{id}";
            public const string View = modelname + "/view/{id}";
            public const string Destroy = modelname + "/delete/{id}";
        }



    }
    public static class AclRoutesName
    {
        public static class AclSubmodule
        {
            public const string List = "acl.submodule.list";
            public const string Add = "acl.submodule.add";
            public const string View = "acl.submodule.view";
            public const string Edit = "acl.submodule.edit";
            public const string Destroy = "acl.submodule.destroy";

        }
        public static class AclRole
        {
            public const string List = "acl.role.list";
            public const string Add = "acl.role.add";
            public const string View = "acl.role.view";
            public const string Edit = "acl.role.edit";
            public const string Destroy = "acl.role.destroy";

        }
    }
}

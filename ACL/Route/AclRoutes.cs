using Google.Protobuf.WellKnownTypes;
using SharedLibrary.Models;
using System.Reflection.Metadata;

namespace ACL.Route
{
    public class AclRoutesUrl
    {

        public const string Root = "api/v1";
        public const string Base = "api/v1/";
        public class AclModule
        {
            public const string List = Base + "modules";
            public const string Add = Base + "modules/add";
            public const string Edit = Base + "modules/edit/{Id}";
            public const string View = Base + "modules/view/{Id}";
            public const string Destroy = Base + "modules/delete/{Id}";
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
        public class AclUserGroupRole
        {
            public const string modelname = "usergroups/roles";
            public const string List = modelname + "/{userGroupId}";
            public const string Update = modelname + "/update";
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
        public static class AclUserGroupRole
        {
            public const string List = "acl.usergroups.role.association";
            public const string Update = "acl.usergroups.role.association.update";
        }
        
            
    }
}

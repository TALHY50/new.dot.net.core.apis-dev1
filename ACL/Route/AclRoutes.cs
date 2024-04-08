﻿using Google.Protobuf.WellKnownTypes;
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
            public const string Edit = Base + "modules/edit/{id}";
            public const string View = Base + "modules/view/{id}";
            public const string Destroy = Base + "modules/delete/{id}";
        }
        public class AclSubModule
        {
            public const string ModelName = Base + "submodules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclCompanyModule
        {
            public const string ModelName = Base + "company/modules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclRolePage
        {
            public const string ModelName = Base + "roles/pages";
            public const string List = ModelName + "/{id}";
            public const string Edit = ModelName + "/update";
        }

    }
    public static class AclRoutesName
    {
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
        public static class SubmoduleRouteNames
        {
            public const string List = "acl.submodule.list";
            public const string Add = "acl.submodule.add";
            public const string View = "acl.submodule.view";
            public const string Edit = "acl.submodule.edit";
            public const string Destroy = "acl.submodule.destroy";
        }
        public static class AclRolePageRouteNames
        {
            public const string List = "acl.role&page.association";
            public const string Edit = "acl.role&page.association.update";
        }

    }
}

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
            public const string Edit = Base + "modules/edit/{id}";
            public const string View = Base + "modules/view/{id}";
            public const string Destroy = Base + "modules/delete/{id}";
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
        public class AclSubModule
        {
            public const string ModelName = Base + "submodules";
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
        public class AclSubmodule
        {
            public const string ModelName = "submodules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclRole
        {
            public const string ModelName = "roles";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclUserGroupRole
        {
            public const string ModelName = "usergroups/roles";
            public const string List = ModelName + "/{userGroupId}";
            public const string Update = ModelName + "/update";
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
        public class AclUserGroupRoutesUrl
        {
            public const string ModelName = Base + "usergroups";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string View = ModelName + "/view/{id}";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/destroy/{id}";
        }
    }
    public static class AclRoutesName
    {
        public static class AclCompanyRouteNames
        {
            public const string List = "acl.company.list";
            public const string Add = "acl.company.add";
            public const string View = "acl.company.show";
            public const string Edit = "acl.company.edit";
            public const string Destroy = "acl.company.destroy";
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
        public static class AclRolePageRouteNames
        {
            public const string List = "acl.role&page.association";
            public const string Edit = "acl.role&page.association.update";
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

        public class AclUserGroupRole
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

    }
}

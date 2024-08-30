using System.ComponentModel;

namespace ACL.Bussiness.Contracts.Requests
{
    public class AclUserGroupRequest
    {
        [DefaultValue("User Group")]
        public string GroupName { get; set; }
        [DefaultValue("Test Name")]
        public string Name { get; set; }
         [DefaultValue(1)]
        public sbyte Status { get; set; }
    }
}

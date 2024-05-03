using System.ComponentModel;

namespace ACL.Requests.V1
{
    public class AclUserGroupRequest
    {
        [DefaultValue("User Group")]
        public string group_name { get; set; }

        [DefaultValue("Test Name")]
        public string name { get; set; }

        [DefaultValue(1)]
        public sbyte status { get; set; }
    }
}

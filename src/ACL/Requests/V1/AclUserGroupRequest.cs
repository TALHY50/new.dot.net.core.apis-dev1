namespace ACL.Requests.V1
{
    public class AclUserGroupRequest
    {
        public string GroupName { get; set; }
        public string Name { get; set; }
        public sbyte Status { get; set; }
    }
}

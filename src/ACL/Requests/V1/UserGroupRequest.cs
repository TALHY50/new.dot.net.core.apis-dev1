namespace ACL.Requests.V1
{
    public class UserGroupRequest
    {
        public string group_name { get; set; }
        public string name { get; set; }
        public sbyte status { get; set; }
    }
}

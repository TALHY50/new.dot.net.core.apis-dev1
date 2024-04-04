using System.Numerics;

namespace ACL.Requests.V1
{
    public class AclModuleRequest
    {
        public ulong id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int sequence { get; set; }
        public string display_name { get; set; }
    }
}

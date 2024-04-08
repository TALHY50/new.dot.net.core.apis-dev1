using ACL.Requests.CustomDataAnotator;
using System.Numerics;

namespace ACL.Requests.V1
{
    public class AclModuleRequest
    {
        //[UniqueValue("AclModules", "Id", ErrorMessage = "Id must be unique.")]
        public ulong id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int sequence { get; set; }
        public string display_name { get; set; }
    }
}

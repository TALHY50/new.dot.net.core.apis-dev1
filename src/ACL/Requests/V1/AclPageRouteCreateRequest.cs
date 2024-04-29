
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;

namespace ACL.Requests.V1
{
    public class AclPageRouteRequest
    {
        [DefaultValue("3002")]
        [Required]
        [Range(1, ulong.MaxValue)]
        [ExistsInDatabase("AclPage", "Id")]
        public ulong page_id { get; set; }

        [DefaultValue("acl.company.list")]
        [Required]
        [StringLength(100)]
        public string route_name { get; set; }

        [DefaultValue("companies")]
        [Required]
        [StringLength(100)]
        public string route_url { get; set; }
    }
}

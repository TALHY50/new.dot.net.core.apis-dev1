
using System.ComponentModel.DataAnnotations;
namespace ACL.Requests.V1
{
    public class AclPageRouteRequest
    {
        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong page_id { get; set; }
        [Required]
        [StringLength(100)]
        public string route_name { get; set; }

        [Required]
        [StringLength(100)]
        public string route_url { get; set; }
    }
}

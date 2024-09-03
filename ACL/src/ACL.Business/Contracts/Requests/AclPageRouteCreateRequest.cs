using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Business.Contracts.Requests
{
    public class AclPageRouteRequest
    {
        [DefaultValue("3002")]
        [Required]
        [Range(1, uint.MaxValue)]
        //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("Page", "Id")]
        public uint PageId { get; set; }

        [DefaultValue("acl.company.list")]
        [Required]
        [StringLength(100)]
        public string RouteName { get; set; }

        [DefaultValue("companies")]
        [Required]
        [StringLength(100)]
        public string RouteUrl { get; set; }
    }
}

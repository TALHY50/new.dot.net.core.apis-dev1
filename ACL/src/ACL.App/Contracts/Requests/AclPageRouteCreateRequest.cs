using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.App.Contracts.Requests
{
    public class AclPageRouteRequest
    {
        [DefaultValue("3002")]
        [Required]
        [Range(1, ulong.MaxValue)]
        //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclPage", "Id")]
        public ulong PageId { get; set; }

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

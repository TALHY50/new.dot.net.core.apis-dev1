
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Database;
using ACL.Interfaces;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Requests.V1
{
    public class AclPageRouteRequest
    {
        [DefaultValue("3002")]
        [Required]
        [Range(1, ulong.MaxValue)]
        [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclPage", "Id")]
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

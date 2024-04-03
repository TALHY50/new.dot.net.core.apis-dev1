using System.ComponentModel.DataAnnotations;

namespace ACL.Requests
{
    public partial class AclCompanyModuleRequest
    {
        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong CompanyId { get; set; }
        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong ModuleId { get; set; }
    }
}

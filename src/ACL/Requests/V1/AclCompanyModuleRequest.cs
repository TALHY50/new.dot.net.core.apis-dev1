using ACL.Requests.CustomDataAnotator;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public partial class AclCompanyModuleRequest
    {
        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyModule]
        public ulong CompanyId { get; set; }

        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyModule]
        public ulong ModuleId { get; set; }
    }


}

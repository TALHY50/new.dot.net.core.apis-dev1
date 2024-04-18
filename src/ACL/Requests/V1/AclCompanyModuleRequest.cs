using ACL.Requests.CustomDataAnotator;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public partial class AclCompanyModuleRequest
    {
        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyModule]
        public ulong company_id { get; set; }

        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyModule]
        public ulong module_id { get; set; }
    }


}

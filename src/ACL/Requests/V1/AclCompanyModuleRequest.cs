using ACL.Requests.CustomDataAnotator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public partial class AclCompanyModuleRequest
    {
        [DefaultValue(1)]
        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyModule]
        public ulong company_id { get; set; }

        [DefaultValue(1001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyModule]
        public ulong module_id { get; set; }
    }


}

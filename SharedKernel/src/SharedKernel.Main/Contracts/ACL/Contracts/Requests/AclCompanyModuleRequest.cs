using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SharedKernel.Main.Contracts.ACL.Contracts.Requests
{
    public partial class AclCompanyModuleRequest
    {
        [DefaultValue(1)]
        [Required]
        [Range(1, ulong.MaxValue)]
        //[UniqueCompanyModule]
        public ulong CompanyId { get; set; }

        [DefaultValue(1001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        //[UniqueCompanyModule]
        public ulong ModuleId { get; set; }
    }


}

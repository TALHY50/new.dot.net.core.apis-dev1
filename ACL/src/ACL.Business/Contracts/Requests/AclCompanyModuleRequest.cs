using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Business.Contracts.Requests
{
    public partial class AclCompanyModuleRequest
    {
        [DefaultValue(1)]
        [Required]
        [Range(1, uint.MaxValue)]
        //[UniqueCompanyModule]
        public uint CompanyId { get; set; }

        [DefaultValue(1001)]
        [Required]
        [Range(1, uint.MaxValue)]
        //[UniqueCompanyModule]
        public uint ModuleId { get; set; }
    }


}

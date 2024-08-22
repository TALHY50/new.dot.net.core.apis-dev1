using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SharedKernel.Main.Contracts.ACL.Contracts.Requests
{
    public class AclPageRequest
    {
        [DefaultValue(3001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong Id { get; set; }

        [DefaultValue(1001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong ModuleId { get; set; }

        [DefaultValue(2001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong SubModuleId { get; set; }

        [DefaultValue("Company List")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [DefaultValue("index")]
        [Required]
        [StringLength(100)]
        public string MethodName { get; set; } = null!;

        [DefaultValue(1)]
        [Required]
        [Range(1, 4)]
        public int MethodType { get; set; }
    }
}

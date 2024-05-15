
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Database;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Requests.V1
{
    public class AclPageRequest
    {
        [DefaultValue(1001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclModule", "Id")]
        public ulong ModuleId { get; set; }

        [DefaultValue(2001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclSubModule", "Id")]
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

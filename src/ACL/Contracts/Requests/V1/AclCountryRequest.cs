using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Infrastructure.Database;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Contracts.Requests.V1;

public partial class AclCountryRequest
{
    [DefaultValue("Bangladesh")]
    [Required]
    [StringLength(50)]
    //[UniqueValue<ApplicationDbContext,ICustomUnitOfWork>("AclCountry", "Name")]
    public string Name { get; set; }

    [DefaultValue("This is beautiful country")]
    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [DefaultValue("bn")]
    [Required]
    [StringLength(50)]
    //[UniqueValue<ApplicationDbContext,ICustomUnitOfWork>("AclCountry", "Code")]
    public string Code { get; set; }

    [DefaultValue(1)]
    public byte Status { get; set; }
    [DefaultValue(1)]
    public ulong Sequence { get; set; }

}

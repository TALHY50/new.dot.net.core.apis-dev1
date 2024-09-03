using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Business.Contracts.Requests;

public partial class AclCountryRequest
{
    [DefaultValue("Bangladesh")]
    [Required]
    [StringLength(50)]
    //[UniqueValue<ApplicationDbContext,ICustomUnitOfWork>("Country", "Name")]
    public string Name { get; set; }

    [DefaultValue("This is beautiful country")]
    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [DefaultValue("bn")]
    [Required]
    [StringLength(50)]
    //[UniqueValue<ApplicationDbContext,ICustomUnitOfWork>("Country", "Code")]
    public string Code { get; set; }

    [DefaultValue(1)]
    public byte Status { get; set; }
    [DefaultValue(1)]
    public uint Sequence { get; set; }

}

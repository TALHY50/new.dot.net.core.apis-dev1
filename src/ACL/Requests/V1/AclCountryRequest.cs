
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests;

public partial class AclCountryRequest
{
    [DefaultValue("Bangladesh")]
    [Required]
    [StringLength(50)]
    public string name { get; set; }

    [DefaultValue("This is beautiful country")]
    [Required]
    [StringLength(255)]
    public string description { get; set; }

    [DefaultValue("bn")]
    [Required]
    [StringLength(50)]
    public string code { get; set; }

    [DefaultValue(1)]
    public byte status { get; set; }
    [DefaultValue(1)]
    public ulong sequence { get; set; }

}

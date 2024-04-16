
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;
using ACL.Requests.CustomDataAnotaTor;

namespace ACL.Requests;

public partial class AclSubModuleEditRequest
{


    [DefaultValue("1004")]
    [Required(ErrorMessage = "module_id is required.")]
    [Range(1, ulong.MaxValue, ErrorMessage = "module_id is required.")]
    [ModuleIdExists]
    public ulong module_id { get; set; }

    [DefaultValue("Company")]
    [Required(ErrorMessage = "name is required.")]
    [MaxLength(100)]
    [UniqueValue("AclSubModule", "Name")]
    public  string name { get; set; }

    [DefaultValue("AclCompanyController")]
    [Required(ErrorMessage = "controller_name is required.")]
    [MaxLength(255)]
    public  string controller_name { get; set; }

    [DefaultValue("<i class='fa fa-angle-double-right'></i>")]
    [Required(ErrorMessage = "icon is required.")]
    [MaxLength(255)]
    public  string icon { get; set; }

    [DefaultValue("100")]
    [Required(ErrorMessage = "sequence is required.")]
    [NonZero(ErrorMessage = "sequence is required.")]
    public int sequence { get; set; }

    [DefaultValue("index")]
    [Required(ErrorMessage = "default_method is required.")]
    [MaxLength(50)]
    public  string default_method { get; set; }

    [DefaultValue("Company Management")]
    [Required(ErrorMessage = "display_name is required.")]
    [MaxLength(100)]
    public  string display_name { get; set; }

}

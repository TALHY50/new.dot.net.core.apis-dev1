
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotaTor;

namespace ACL.Requests;

public partial class AclSubModuleRequest
{
    [Required(ErrorMessage = "id is required.")]
    [NonZero(ErrorMessage = "id is required.")]
    public ulong id { get; set; }

    [Required(ErrorMessage = "module_id is required.")]
    [NonZero(ErrorMessage = "module_id is required.")]
    public ulong module_id { get; set; }

    [Required(ErrorMessage = "name is required.")]
    public  string name { get; set; }

    [Required(ErrorMessage = "controller_name is required.")]
    public  string controller_name { get; set; }

    [Required(ErrorMessage = "icon is required.")]
    public  string icon { get; set; }

    [Required(ErrorMessage = "sequence is required.")]
    [NonZero(ErrorMessage = "sequence is required.")]
    public int sequence { get; set; }

    [Required(ErrorMessage = "default_method is required.")]
    public  string default_method { get; set; }


    [Required(ErrorMessage = "display_name is required.")]
    public  string display_name { get; set; }

}

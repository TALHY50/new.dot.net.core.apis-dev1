using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Contracts.Requests;

public partial class AclSubModuleRequest
{
    [DefaultValue("2055")]
    [Required(ErrorMessage = "id is required.")]
    [Range(1, ulong.MaxValue, ErrorMessage = "id is required.")]
    public ulong Id { get; set; }

    [DefaultValue("1004")]
    [Required(ErrorMessage = "module_id is required.")]
    [Range(1, ulong.MaxValue, ErrorMessage = "module_id is required.")]
    public ulong ModuleId { get; set; }

    [DefaultValue("Company")]
    [Required(ErrorMessage = "name is required.")]
    [MaxLength(100)]
    public  string Name { get; set; }

    [DefaultValue("AclCompanyController")]
    [Required(ErrorMessage = "controller_name is required.")]
    [MaxLength(255)]
    public  string ControllerName { get; set; }

    [DefaultValue("<i class='fa fa-angle-double-right'></i>")]
    [Required(ErrorMessage = "icon is required.")]
    [MaxLength(255)]
    public  string Icon { get; set; }

    [DefaultValue("100")]
    [Required(ErrorMessage = "sequence is required.")]
    [Range(1, ulong.MaxValue, ErrorMessage = "sequence is required.")]
    public int Sequence { get; set; }

    [DefaultValue("index")]
    [Required(ErrorMessage = "default_method is required.")]
    [MaxLength(50)]
    public  string DefaultMethod { get; set; }

    [DefaultValue("Company Management")]
    [Required(ErrorMessage = "display_name is required.")]
    [MaxLength(100)]
    public  string DisplayName { get; set; }

}

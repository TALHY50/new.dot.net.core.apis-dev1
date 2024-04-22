
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests;

public partial class AclRoleRequest
{

    [DefaultValue("Admin Role")]
    [Required(ErrorMessage = "name is required.")]
    [UniqueValue("AclRole", "Name")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "name must be between 3 to 100 characters.")]
    public  string name { get; set; }

    [DefaultValue("Admin")]
    [Required(ErrorMessage = "title is required.")]
    [UniqueValue("AclRole", "Title")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "title must be between 3 to 100 characters.")]
    public  string title { get; set; }


    [Required(ErrorMessage = "status is required.")]
    [Range(1, 2, ErrorMessage = "Value must be between {1} and {2}.")]
    public sbyte status { get; set; }


}

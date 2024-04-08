
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests;

public partial class AclRoleRequest
{


    [Required(ErrorMessage = "name is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "name must be between {2} and {1} characters.")]
    public  string name { get; set; }


    [Required(ErrorMessage = "title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "title must be between {2} and {1} characters.")]
    public  string title { get; set; }


    [Required(ErrorMessage = "status is required.")]
    [Range(1, 2, ErrorMessage = "Value must be between {1} and {2}.")]
    public sbyte status { get; set; }


}

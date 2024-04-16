
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;

namespace ACL.Requests.V1;

public partial class AclForgetPasswordRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [UserEmailExists]
    public string email { get; set; }


}

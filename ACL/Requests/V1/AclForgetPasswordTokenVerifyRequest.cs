
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1;

public partial class AclForgetPasswordTokenVerifyRequest
{
    [Required(ErrorMessage = "Token is required")]
    public string token { get; set; }

    [Required(ErrorMessage = "New password is required")]
    public string new_password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("new_password", ErrorMessage = "The new password and confirmation password do not match.")]
    public string password_confirmation { get; set; }


}

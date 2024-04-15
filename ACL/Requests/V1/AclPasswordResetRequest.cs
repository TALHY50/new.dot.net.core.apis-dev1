
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;

namespace ACL.Requests.V1;

public partial class AclPasswordResetRequest
{
    [Required(ErrorMessage = "User ID is required")]
    [UserIdExists]
    public ulong user_id { get; set; } 

    [Required(ErrorMessage = "Current password is required")]
    public string current_password { get; set; }

    [Required(ErrorMessage = "New password is required")]
    public string new_password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("new_password", ErrorMessage = "The new password and confirmation password do not match.")]
    public string password_confirmation { get; set; }


}

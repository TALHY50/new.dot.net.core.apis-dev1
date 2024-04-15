
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;

namespace ACL.Requests.V1;

public partial class AclPasswordResetRequest
{
    [DefaultValue("10")]
    [Required(ErrorMessage = "User ID is required")]
    [Range(1, ulong.MaxValue, ErrorMessage = "User ID greater than 0.")]
    [UserIdExists]
    public ulong user_id { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Current password is required")]
    public string current_password { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "New password is required")]
    public string new_password { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("new_password", ErrorMessage = "The new password and confirmation password do not match.")]
    public string password_confirmation { get; set; }


}

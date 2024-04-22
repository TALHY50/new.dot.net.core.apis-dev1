
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1;

public partial class AclForgetPasswordTokenVerifyRequest
{
    [DefaultValue("bba47d83926a8d98cdc4affeee7b91459a08734b6e40da5ac0f69eaf78fb6017")]
    [Required(ErrorMessage = "Token is required")]
    public string token { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "New password is required")]
    public string new_password { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("new_password", ErrorMessage = "The new password and confirmation password do not match.")]
    public string password_confirmation { get; set; }


}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Application.Contracts.Requests;

public partial class AclForgetPasswordTokenVerifyRequest
{
    [DefaultValue("bba47d83926a8d98cdc4affeee7b91459a08734b6e40da5ac0f69eaf78fb6017")]
    [Required(ErrorMessage = "Token is required")]
    public string Token { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "New password is required")]
    public string NewPassword { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string PasswordConfirmation { get; set; }


}

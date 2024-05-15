using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Infrastructure.Database;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Requests.V1;

public partial class AclPasswordResetRequest
{
    [DefaultValue("10")]
    [Required(ErrorMessage = "User ID is required")]
    [Range(1, ulong.MaxValue, ErrorMessage = "User ID greater than 0.")]
    [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclUser", "Id")]
    public ulong UserId { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Current password is required")]
    public string CurrentPassword { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "New password is required")]
    public string NewPassword { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string PasswordConfirmation { get; set; }


}

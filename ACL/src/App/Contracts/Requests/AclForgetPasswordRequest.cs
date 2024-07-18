using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Contracts.Requests;

public partial class AclForgetPasswordRequest
{
    [DefaultValue("admin@gmail.com")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclUser","Email")]
    public string Email { get; set; }


}

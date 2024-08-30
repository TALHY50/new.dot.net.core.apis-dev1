using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Bussiness.Contracts.Requests;

public partial class AclForgetPasswordRequest
{
    [DefaultValue("admin@gmail.com")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("User","Email")]
    public string Email { get; set; }


}

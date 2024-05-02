
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Database;
using ACL.Interfaces;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Requests.V1;

public partial class AclForgetPasswordRequest
{
    [DefaultValue("admin@gmail.com")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclUser","Email")]
    public string email { get; set; }


}

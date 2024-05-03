using ACL.Database;
using ACL.Interfaces;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests
{
    public class AclRoleAndPageAssocUpdateRequest
    {
        [DefaultValue(1)]
        [Required]
        [ExistsInDatabase<ApplicationDbContext, ICustomUnitOfWork>("AclRole", "Id")]
        [Range(1, int.MaxValue)]
        public ulong role_id { get; set; }

        [DefaultValue(new int[] { 1, 2 })]
        [Required]
        [MinLength(1, ErrorMessage = "Array must contain at least one element.")]
        [ArrayOfIntegers]
        public int[] PageIds { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Contracts.Requests.CustomDataAnotator;
using ACL.Infrastructure.Database;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Contracts.Requests.V1
{
    public class AclRoleAndPageAssocUpdateRequest
    {
        [DefaultValue(1)]
        [Required]
        [ExistsInDatabase<ApplicationDbContext, ICustomUnitOfWork>("AclRole", "Id")]
        [Range(1, int.MaxValue)]
		public ulong RoleId { get; set; }
		[Required]
        [DefaultValue(new int[] { 1, 2 })]
		[MinLength(1, ErrorMessage = "Array must contain at least one element.")]
		[ArrayOfIntegers]
		public int[] PageIds { get; set; }
	}
}

using ACL.Database;
using ACL.Interfaces;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests
{
	public class AclRoleAndPageAssocUpdateRequest
	{
		[Required]
        [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclRole", "Id")]
        [Range(1, int.MaxValue)]
		public ulong RoleId { get; set; }
		[Required]
		[MinLength(1, ErrorMessage = "Array must contain at least one element.")]
		[ArrayOfIntegers]
		public int[] PageIds { get; set; }
	}
}

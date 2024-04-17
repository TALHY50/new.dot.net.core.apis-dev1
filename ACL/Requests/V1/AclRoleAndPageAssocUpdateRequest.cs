using ACL.Requests.CustomDataAnotator;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests
{
	public class AclRoleAndPageAssocUpdateRequest
	{
		[Required]
        [ExistsInDatabase("AclRole", "Id")]
        [Range(1, int.MaxValue)]
		public ulong role_id { get; set; }
		[Required]
		[MinLength(1, ErrorMessage = "Array must contain at least one element.")]
		[ArrayOfIntegers]
		public int[] PageIds { get; set; }
	}
}

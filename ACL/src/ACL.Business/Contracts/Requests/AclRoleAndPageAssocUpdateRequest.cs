using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Business.Contracts.Requests
{
    public class AclRoleAndPageAssocUpdateRequest
    {
        [DefaultValue(1)]
        [Required]
        //[ExistsInDatabase<ApplicationDbContext, ICustomUnitOfWork>("Role", "Id")]
        [Range(1, int.MaxValue)]
		public uint RoleId { get; set; }
		[Required]
        [DefaultValue(new int[] { 1, 2 })]
		[MinLength(1, ErrorMessage = "Array must contain at least one element.")]
		//[ArrayOfIntegers]
		public int[] PageIds { get; set; }
	}
}

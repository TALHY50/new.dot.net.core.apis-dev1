namespace ACL.Requests
{
    using ACL.Database.Models;
    using ACL.Interfaces;
	using ACL.Requests.CustomDataAnotator;
	using Org.BouncyCastle.Asn1.Ocsp;
	using System.ComponentModel.DataAnnotations;
	public class AclRoleAndPageAssocUpdateRequest
	{
		[Required]
        [ExistsInDatabase(typeof(AclRolePage))]
		[Range(1, int.MaxValue)]
		public ulong role_id { get; set; }
		[Required]
		[MinLength(1, ErrorMessage = "Array must contain at least one element.")]
		[ArrayOfIntegers]
		public int[] PageIds { get; set; }
	}
}

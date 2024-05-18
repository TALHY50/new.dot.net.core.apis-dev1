using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Contracts.Requests.V1
{
     /// <inheritdoc/>
    public class AclUserGroupRoleRequest
    {
        [DefaultValue("10")]
        [Required(ErrorMessage = "User group ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User group ID must be a valid integer greater than 0")]
        //[ExistsInDatabase("AclUsergroup", "Id")]
        //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclUsergroup", "Id")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public  ulong UserGroupId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        /// <inheritdoc/>
        [DefaultValue(new ulong[] { 1, 2 })]
        [Required(ErrorMessage = "Role IDs are required")]
        [MinLength(1, ErrorMessage = "Exactly one role id is required.")]
        //[AclRoleExists]
        public required ulong[] RoleIds { get; set; }
    }
}

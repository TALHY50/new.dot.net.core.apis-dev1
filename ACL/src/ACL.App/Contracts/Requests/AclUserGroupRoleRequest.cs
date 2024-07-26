using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.App.Contracts.Requests
{
     /// <inheritdoc/>
    public class AclUserGroupRoleRequest
    {
        [DefaultValue("10")]
        [Required(ErrorMessage = "User group ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User group ID must be a valid integer greater than 0")]
        public  ulong UserGroupId { get; set; }


        [DefaultValue(new ulong[] { 1, 2 })]
        [Required(ErrorMessage = "Role IDs are required")]
        [MinLength(1, ErrorMessage = "Exactly one role id is required.")]
        public required ulong[] RoleIds { get; set; }
    }
}

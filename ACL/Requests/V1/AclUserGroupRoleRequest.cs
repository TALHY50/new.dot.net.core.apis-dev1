
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;
namespace ACL.Requests.V1
{
    public class AclUserGroupRoleRequest
    {
        [Required(ErrorMessage = "User group ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User group ID must be a valid integer greater than 0")]
        [AclUserGroupExists]
        public ulong user_group_id { get; set; }

        [Required(ErrorMessage = "Role IDs are required")]
        [AclRoleExists]
        public ulong[] role_ids { get; set; }
    }
}

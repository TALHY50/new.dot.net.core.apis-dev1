
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;
namespace ACL.Requests.V1
{
    public class AclUserGroupRoleRequest
    {
        [DefaultValue("10")]
        [Required(ErrorMessage = "User group ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User group ID must be a valid integer greater than 0")]
        [ExistsInDatabase("AclUsergroup", "Id")]
        public ulong user_group_id { get; set; }

        [DefaultValue(new ulong[] { 1,2})]
        [Required(ErrorMessage = "Role IDs are required")]
        [MinLength(1, ErrorMessage = "Exactly one role id is required.")]
        [AclRoleExists]
        public ulong[] role_ids { get; set; }
    }
}

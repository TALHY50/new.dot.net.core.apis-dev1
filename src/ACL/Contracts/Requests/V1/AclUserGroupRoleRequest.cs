﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Contracts.Requests.CustomDataAnotator;
using ACL.Infrastructure.Database;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Contracts.Requests.V1
{
    public class AclUserGroupRoleRequest
    {
        [DefaultValue("10")]
        [Required(ErrorMessage = "User group ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User group ID must be a valid integer greater than 0")]
        //[ExistsInDatabase("AclUsergroup", "Id")]
        //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclUsergroup", "Id")]
        public ulong UserGroupId { get; set; }

        [DefaultValue(new ulong[] { 1, 2 })]
        [Required(ErrorMessage = "Role IDs are required")]
        [MinLength(1, ErrorMessage = "Exactly one role id is required.")]
        [AclRoleExists]
        public ulong[] RoleIds { get; set; }
    }
}
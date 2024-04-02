using System;
using System.Collections.Generic;

namespace ACL.Database.Models;

public partial class AclRolePage
{
    public ulong Id { get; set; }

    public ulong RoleId { get; set; }

    public ulong PageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

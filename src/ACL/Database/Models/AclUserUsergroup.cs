using System;
using System.Collections.Generic;

namespace ACL.Database.Models;

public partial class AclUserUsergroup
{
    public ulong Id { get; set; }

    public ulong UsergroupId { get; set; }

    public ulong UserId { get; set; }

    public ulong CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

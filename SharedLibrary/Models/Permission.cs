using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Permission
{
    public uint Id { get; set; }

    public string Key { get; set; } = null!;

    public string? TableName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();
}

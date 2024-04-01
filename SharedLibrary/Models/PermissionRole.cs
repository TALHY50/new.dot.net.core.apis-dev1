using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PermissionRole
{
    public uint Id { get; set; }

    public uint PermissionId { get; set; }

    public uint RoleId { get; set; }

    public virtual Permission Permission { get; set; } = null!;
}

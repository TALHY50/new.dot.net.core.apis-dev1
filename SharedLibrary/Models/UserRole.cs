using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserRole
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public uint RoleId { get; set; }

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ACL.Database.Models;

public partial class AclUsertypeSubmodule
{
    public ulong Id { get; set; }

    public byte UserTypeId { get; set; }

    public uint SubModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace ACL.Database.Models;

public partial class AclUsergroupRole
{
    public ulong Id { get; set; }

    public ulong UsergroupId { get; set; }

    public ulong RoleId { get; set; }

    public ulong CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
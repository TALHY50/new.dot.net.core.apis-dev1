﻿using System;
using System.Collections.Generic;

namespace ACL.Database.Models;

public partial class AclPageRoute
{
    public ulong Id { get; set; }

    public ulong? PageId { get; set; }

    public string? RouteName { get; set; }

    public string? RouteUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

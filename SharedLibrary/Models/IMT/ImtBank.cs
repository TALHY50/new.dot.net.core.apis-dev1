﻿using System;
using System.Collections.Generic;

namespace SharedLibrary.Models.IMT;

public partial class ImtBank
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? Url { get; set; }

    public string? Logo { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

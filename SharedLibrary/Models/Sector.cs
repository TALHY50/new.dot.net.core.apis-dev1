using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Sector
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string NameTr { get; set; } = null!;

    public string? Code { get; set; }

    /// <summary>
    /// 0=inactive; 1=active
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// 0=customer; 2=merchant
    /// </summary>
    public sbyte Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

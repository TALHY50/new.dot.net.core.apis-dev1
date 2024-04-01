using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ChecklistControl
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Information { get; set; }

    /// <summary>
    /// 1 = active, 0 = inactive
    /// </summary>
    public sbyte UploadFile { get; set; }

    /// <summary>
    /// 1 = required, 0 = not required
    /// </summary>
    public sbyte IsRequired { get; set; }

    /// <summary>
    /// 1 = active, 0 = inactive
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

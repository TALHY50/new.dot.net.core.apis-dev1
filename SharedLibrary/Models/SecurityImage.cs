using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SecurityImage
{
    public int Id { get; set; }

    public string BrandCode { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    /// <summary>
    /// 1 = active, 0 = inactive
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

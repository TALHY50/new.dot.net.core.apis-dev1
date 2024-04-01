using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BinRangeQp
{
    public int Id { get; set; }

    /// <summary>
    /// Bin start form
    /// </summary>
    public string? BinFrom { get; set; }

    /// <summary>
    /// Bin to
    /// </summary>
    public string? BinTo { get; set; }

    /// <summary>
    /// Response as json format
    /// </summary>
    public string? Response { get; set; }

    /// <summary>
    /// 6  = 6 digit bin range, 8 = 8 digit bin range
    /// </summary>
    public sbyte? BinLength { get; set; }

    public int? BankCardBrandId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

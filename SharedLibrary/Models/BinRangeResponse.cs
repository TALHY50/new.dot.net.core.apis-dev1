using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BinRangeResponse
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
    /// 1  = 6 digit bin range, 2 = 8 digit bin range
    /// </summary>
    public sbyte? BinDigit { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

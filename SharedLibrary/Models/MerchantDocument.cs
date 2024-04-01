using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantDocument
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string? File1Path { get; set; }

    public string? File2Path { get; set; }

    public string? File3Path { get; set; }

    /// <summary>
    /// 0=&gt;missing;1=&gt;approved;2=&gt;rejected
    /// </summary>
    public sbyte File1Status { get; set; }

    /// <summary>
    /// 0=&gt;missing;1=&gt;approved;2=&gt;rejected
    /// </summary>
    public sbyte File2Status { get; set; }

    /// <summary>
    /// 0=&gt;missing;1=&gt;approved;2=&gt;rejected
    /// </summary>
    public sbyte File3Status { get; set; }

    public string? File1Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? File2Comments { get; set; }

    public string? File3Comments { get; set; }

    public string? OtherFile1Path { get; set; }

    public string? OtherFile2Path { get; set; }

    public string? OtherFile3Path { get; set; }

    /// <summary>
    /// 0=missing, 1=approved, 2=rejected
    /// </summary>
    public sbyte? OtherFile1Status { get; set; }

    /// <summary>
    /// 0=missing, 1=approved, 2=rejected
    /// </summary>
    public sbyte? OtherFile2Status { get; set; }

    /// <summary>
    /// 0=missing, 1=approved, 2=rejected
    /// </summary>
    public sbyte? OtherFile3Status { get; set; }

    public string? OtherFile1Comments { get; set; }

    public string? OtherFile2Comments { get; set; }

    public string? OtherFile3Comments { get; set; }
}

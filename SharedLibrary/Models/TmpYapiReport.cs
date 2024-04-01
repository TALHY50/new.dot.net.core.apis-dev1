using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpYapiReport
{
    public int Id { get; set; }

    public string TerminalNo { get; set; } = null!;

    public string ReferenceNo { get; set; } = null!;

    public double? Amount { get; set; }

    public double? NetAmount { get; set; }

    public double? Commission { get; set; }

    public sbyte? RemoteStatus { get; set; }

    public string Data { get; set; } = null!;

    /// <summary>
    /// 0=&gt;Not Processed, 1=&gt;Processed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}

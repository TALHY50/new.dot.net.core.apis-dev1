using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Allocation
{
    public uint Id { get; set; }

    public string PosId { get; set; } = null!;

    public string? PosName { get; set; }

    /// <summary>
    /// 0=&gt;all, 1=&gt;credit card, 2=&gt; debit card
    /// </summary>
    public sbyte? CardType { get; set; }

    /// <summary>
    /// 0-&gt;all,1-&gt;debit card,2-&gt;credit card
    /// </summary>
    public sbyte? TransactionType { get; set; }

    public int? TransactionLimit { get; set; }

    public double? AmountLimit { get; set; }

    public DateTime? FromTime { get; set; }

    public DateTime? ToTime { get; set; }

    public int? ProgramId { get; set; }

    public string? ProgramName { get; set; }

    /// <summary>
    /// 1-active;0-inactive;
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}

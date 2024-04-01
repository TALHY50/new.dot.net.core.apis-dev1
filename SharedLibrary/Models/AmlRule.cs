using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AmlRule
{
    public int Id { get; set; }

    /// <summary>
    /// Rule unique code.(Constant Value)
    /// </summary>
    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }

    /// <summary>
    /// 1 =&gt; Active, 0 =&gt; Inactive
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// Codes of transactions(Constants value)
    /// </summary>
    public string TransactionCodes { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantNote
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public int MerchantId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    /// <summary>
    /// 0 =&gt; close , 1 =&gt; open
    /// </summary>
    public sbyte Status { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public string? UpdatedByName { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

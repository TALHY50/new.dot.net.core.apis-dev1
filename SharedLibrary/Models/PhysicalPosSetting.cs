using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PhysicalPosSetting
{
    public int Id { get; set; }

    /// <summary>
    /// Type of Physical POS. Example: Oxivo =&gt; 1, Pavo =&gt; 2, Taxi =&gt; 3, MT =&gt; 4, WD =&gt; 5, Hugin =&gt; 6, Sari Texi =&gt; 7, Virtual POS =&gt; 8.
    /// </summary>
    public sbyte? Type { get; set; }

    public string? LastTransactionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

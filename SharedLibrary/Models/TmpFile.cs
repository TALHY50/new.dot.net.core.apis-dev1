using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpFile
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    /// <summary>
    /// 1 =&gt; yapi , 2 =&gt; fp_mt
    /// </summary>
    public sbyte Type { get; set; }

    /// <summary>
    /// 0 =&gt; pending , 1 =&gt; completed , 2 =&gt; in progress
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}

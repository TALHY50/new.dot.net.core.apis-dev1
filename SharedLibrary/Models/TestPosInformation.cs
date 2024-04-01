using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TestPosInformation
{
    public int Id { get; set; }

    /// <summary>
    /// test_pos primary key
    /// </summary>
    public int TestPosId { get; set; }

    public string Info { get; set; } = null!;

    /// <summary>
    /// error response
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// 0=&gt;inactive, 1=&gt;active
    /// </summary>
    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

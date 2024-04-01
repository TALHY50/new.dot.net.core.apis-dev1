using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AmlRuleViolationRecord
{
    public int Id { get; set; }

    public int AmlId { get; set; }

    public int AmlRuleId { get; set; }

    /// <summary>
    /// Type of transactions
    /// </summary>
    public string? Description { get; set; }
}

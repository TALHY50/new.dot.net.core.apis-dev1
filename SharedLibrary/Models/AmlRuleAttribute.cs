using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AmlRuleAttribute
{
    public int Id { get; set; }

    public int AmlRuleId { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Unique code for role attributes(Constant Value)
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Type must be format of input field
    /// </summary>
    public string Type { get; set; } = null!;
}

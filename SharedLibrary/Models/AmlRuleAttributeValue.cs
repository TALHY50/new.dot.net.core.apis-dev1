using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AmlRuleAttributeValue
{
    public int Id { get; set; }

    public int AmlRuleId { get; set; }

    public int CurrencyId { get; set; }

    public int AmlRuleAttributeId { get; set; }

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }

    /// <summary>
    /// User Categories in Comma Separated way. Example: 1,2 
    /// </summary>
    public string? UserCategories { get; set; }

    /// <summary>
    /// 1 -&gt; Active, 2 -&gt; Passive
    /// </summary>
    public sbyte? RuleCategory { get; set; }

    /// <summary>
    /// 1 =&gt; Active, 0 =&gt; Inactive
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Value of rule attribute
    /// </summary>
    public string? Value { get; set; }
}

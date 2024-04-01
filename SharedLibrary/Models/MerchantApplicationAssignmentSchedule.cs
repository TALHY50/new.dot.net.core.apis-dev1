using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantApplicationAssignmentSchedule
{
    public int Id { get; set; }

    /// <summary>
    /// merchant application primary id
    /// </summary>
    public int MerchantApplicationId { get; set; }

    /// <summary>
    /// saler expert user id
    /// </summary>
    public int UserId { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public string? Notes { get; set; }

    /// <summary>
    /// 0 =&gt; pending , 1 =&gt; approved , 2 =&gt; rejected
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

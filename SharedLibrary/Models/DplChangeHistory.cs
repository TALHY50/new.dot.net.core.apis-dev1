using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DplChangeHistory
{
    public int Id { get; set; }

    public int DplId { get; set; }

    public int MerchantId { get; set; }

    public int UserId { get; set; }

    public double? Amount { get; set; }

    public int CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? MaxNumberOfUses { get; set; }

    public string? OldData { get; set; }

    public string? NewData { get; set; }

    public DateTime? ExpireDate { get; set; }

    /// <summary>
    /// 0=not enabled, 1= enabled
    /// </summary>
    public sbyte? IsEnabled { get; set; }

    /// <summary>
    /// user id of who created
    /// </summary>
    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

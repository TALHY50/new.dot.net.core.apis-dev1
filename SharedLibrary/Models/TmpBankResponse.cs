using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpBankResponse
{
    public int Id { get; set; }

    /// <summary>
    /// Sale order_id
    /// </summary>
    public string OrderId { get; set; } = null!;

    /// <summary>
    /// bank_landing_response from CCPayment
    /// </summary>
    public string? BankResponse { get; set; }

    /// <summary>
    /// Payment extras/session_data
    /// </summary>
    public string? SessionData { get; set; }

    /// <summary>
    /// 0 = Not Processed
    /// 1 = Processed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpPaymentRecordAction
{
    public long Id { get; set; }

    /// <summary>
    /// value could be order_id or tmp_payment_record_id
    /// </summary>
    public string ReferenceId { get; set; } = null!;

    /// <summary>
    /// 1=tmp_payment_record_id , 2= order_id
    /// </summary>
    public sbyte ReferenceType { get; set; }

    /// <summary>
    /// 0 = delete, 1= update
    /// </summary>
    public sbyte Type { get; set; }

    /// <summary>
    /// After where keyword. update for which rows
    /// </summary>
    public string? WhereBy { get; set; }

    /// <summary>
    /// after set keyword. 
    /// </summary>
    public string? UpdateValue { get; set; }

    /// <summary>
    /// value to avoid check order status cron job
    /// </summary>
    public bool IsAvoidCheckOrderStatus { get; set; }

    public DateTime? CreatedAt { get; set; }
}

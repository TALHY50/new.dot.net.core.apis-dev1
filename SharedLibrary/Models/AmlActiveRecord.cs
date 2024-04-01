using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AmlActiveRecord
{
    public uint Id { get; set; }

    public int? CaseNo { get; set; }

    /// <summary>
    /// 1=&gt;completed, 2=&gt; Rejected, 3=&gt;pending, 4=&gt;Stand By
    /// </summary>
    public int AmlApprovalStatus { get; set; }

    public string TransactionableType { get; set; } = null!;

    public int? TransactionableId { get; set; }

    public int? ReceiverTransactionableId { get; set; }

    public int UserId { get; set; }

    public int CurrencyId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPhone { get; set; } = null!;

    public int? ToUserId { get; set; }

    public string? ToUserName { get; set; }

    public string? ToUserEmail { get; set; }

    public string? ToUserPhone { get; set; }

    public double Amount { get; set; }

    public string? InputData { get; set; }

    public string Remarks { get; set; } = null!;

    /// <summary>
    /// Old AML =&gt; 0, User Panel =&gt; 1, Admin Panel =&gt; 2, CCPayment Panel =&gt; 3, Merchant Panel =&gt; 4
    /// </summary>
    public sbyte? Panel { get; set; }

    public int? ActionByUserId { get; set; }

    public string? ActionByIp { get; set; }

    public DateTime? ActionDatetime { get; set; }

    /// <summary>
    /// JSON formatted violation record string
    /// </summary>
    public string? ViolationRecords { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

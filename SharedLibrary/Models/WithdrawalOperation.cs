using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WithdrawalOperation
{
    public int Id { get; set; }

    public int WithdrawalId { get; set; }

    public string PaymentId { get; set; } = null!;

    /// <summary>
    /// 1 = withdrawal reject, 2 = withdrawal Approve, 3 = AML withdrawal Reject, 4 = AML withdrawal approve, 5 = Cashout to bank reject, 6 = Cashout to bank approve
    /// </summary>
    public sbyte Type { get; set; }

    public double? Cot { get; set; }

    public int? SipayBankId { get; set; }

    public DateTime? CreatedAt { get; set; }
}

using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WithdrawalOperationsOutgoing
{
    public int Id { get; set; }

    public string PaymentId { get; set; } = null!;

    /// <summary>
    /// id from withdrawal_operations table
    /// </summary>
    public int OperationId { get; set; }

    /// <summary>
    /// 1=withdrawal reject, 2=withdrawal Approve, 3=AML withdrawal Reject, 4=AML withdrawal approve, 5=Cashout to bank reject, 6=Cashout to bank approve
    /// </summary>
    public sbyte OperationType { get; set; }

    public string TransactionObject { get; set; } = null!;

    public string UserObject { get; set; } = null!;

    public string? CurrencyObject { get; set; }

    public string? MerchantObject { get; set; }

    public string? ExtraData { get; set; }

    public DateTime? CreatedAt { get; set; }
}

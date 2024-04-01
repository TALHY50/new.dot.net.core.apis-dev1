using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Withdrawal
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public int UserId { get; set; }

    public int TransactionStateId { get; set; }

    public int WithdrawalMethodId { get; set; }

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public double? Cost { get; set; }

    public string? PlatformId { get; set; }

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? AdminProcessDate { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? WalletId { get; set; }

    public string? BankName { get; set; }

    public string? Iban { get; set; }

    public string? SwiftCode { get; set; }

    public int BankStaticId { get; set; }

    public int SipayBankAccountId { get; set; }

    public string? AccountHolderName { get; set; }

    public string? GsmNumber { get; set; }

    public string? Name { get; set; }

    public sbyte? UserType { get; set; }

    public string? RefundReason { get; set; }

    public string? RejectReason { get; set; }

    /// <summary>
    /// 1=IBAN, 2=Bank Account, 3=paypal, 4=stipe, 5=authorize.net, 6=Automatic Withdrawal
    /// </summary>
    public sbyte? DestinationType { get; set; }

    /// <summary>
    /// 0=default (finflow disable &amp; manually approve/reject); 1 = sent to finflow from merchant panel and successful; 2 = sent to finflow from merchant panel and rejected, now admin can send again or manually approve/reject; 3 = sent to finflow from admin panel and successful; 4 = sent to finflow from admin panel and rejected, 5 = customized cost , 6 = imported withdrawal
    /// </summary>
    public sbyte? FlowType { get; set; }

    public int? AdminApproveById { get; set; }

    public string? AdminApproveByName { get; set; }

    public string? UniqueId { get; set; }

    public string? UniqueString { get; set; }

    /// <summary>
    /// sorguno number that will be generated on bank side
    /// </summary>
    public string? RemoteTransactionId { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}

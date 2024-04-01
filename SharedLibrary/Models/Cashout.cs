using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Cashout
{
    public int Id { get; set; }

    public string? PaymentId { get; set; }

    public int MerchantId { get; set; }

    public int? UserId { get; set; }

    /// <summary>
    /// 0=customer, 2=merchant
    /// </summary>
    public sbyte? UserType { get; set; }

    public int? BankStaticId { get; set; }

    public int? SipayBankAccountId { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }

    /// <summary>
    /// 1=&gt;send money, 2=&gt;btob, 3=&gt;btoc, 4=&gt;sendmoney to nonbrand, 5=&gt;sendmoney to bank, 6=&gt;sendmoney to merchant, 7=&gt;request money, 8=&gt;btou, 9=&gt;ctoc cashout to bank
    /// </summary>
    public int Type { get; set; }

    public string? IdTckn { get; set; }

    public string? GsmNumber { get; set; }

    public string? BankName { get; set; }

    public double? Gross { get; set; }

    public double? Net { get; set; }

    public double? Fee { get; set; }

    public double? Cost { get; set; }

    public double Amount { get; set; }

    public string? Iban { get; set; }

    public string? Currency { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? CurrencyId { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// 1/2/3 (1=Completed, 2=Rejected, 3=Pending)
    /// </summary>
    public int Status { get; set; }

    public int CashoutFileHistoriesId { get; set; }

    public string? RejectReason { get; set; }

    /// <summary>
    /// 0=default (finflow disable &amp; manually approve/reject); 1 = sent to finflow from merchant panel and successful; 2 = sent to finflow from merchant panel and rejected, now admin can send again or manually approve/reject; 3 = sent to finflow from admin panel and successful; 4 = sent to finflow from admin panel and rejected; 5 = Auto Deduct Customized Cost
    /// </summary>
    public sbyte? FlowType { get; set; }

    public int? AdminApproveById { get; set; }

    public string? AdminApprroveByName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// 1=cashout requested from merchant panel; 2=cashout requested from api;
    /// </summary>
    public sbyte Source { get; set; }

    public string? UniqueId { get; set; }

    public string? UniqueString { get; set; }

    /// <summary>
    /// wallet gate account number
    /// </summary>
    public string? RemoteAccountNumber { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}

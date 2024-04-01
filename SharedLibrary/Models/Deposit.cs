using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Deposit
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public string? OrderId { get; set; }

    public string? RemoteOrderId { get; set; }

    public int UserId { get; set; }

    public int TransactionStateId { get; set; }

    public int DepositMethodId { get; set; }

    public double Gross { get; set; }

    public double Fee { get; set; }

    public double Net { get; set; }

    public double? Cost { get; set; }

    public double? TotalRefundedAmount { get; set; }

    public double? EndUserCommissionPercentage { get; set; }

    public double? EndUserCommissionFixed { get; set; }

    public string? IbanNo { get; set; }

    public sbyte? CardType { get; set; }

    public string? CreditCardNo { get; set; }

    public string? CardHolderName { get; set; }

    public int? PosId { get; set; }

    public string? BankName { get; set; }

    public string? TransactionReceipt { get; set; }

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? AdminProcessDate { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? WalletId { get; set; }

    public string? Message { get; set; }

    public string? PnrCode { get; set; }

    public sbyte NumberOfEdit { get; set; }

    public string? Reason { get; set; }

    public string? Name { get; set; }

    public string? GsmNumber { get; set; }

    /// <summary>
    /// 0=&gt;Customer, 2=&gt;Merchant
    /// </summary>
    public sbyte UserType { get; set; }

    /// <summary>
    /// 1=&gt;Automation, Manual=&gt;2
    /// </summary>
    public sbyte? AutomationStatus { get; set; }

    public string? CustomerIban { get; set; }

    public string? RemoteReceiptNo { get; set; }

    public sbyte? MigrationStatus { get; set; }

    /// <summary>
    /// 1=&gt;Created by admin, 2=&gt;Finflow, 3=&gt;Manual eft, 4=&gt;Eft automation by sipay
    /// </summary>
    public sbyte DepositSource { get; set; }

    public int? CreatedById { get; set; }

    public int? ApproveRejectById { get; set; }

    public string? UniqueString { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }

    public const int MAX_NUMBER_OF_EDIT = 1;
    public const int MAX_NUMBER_OF_DEPOSIT_REQUEST = 3;
    public const int DEPOSIT_METHOD_EFT = 4;
    public const int CREDIT_CARD = 1;
    public const int CARD_TYPE_CREDIT = 1;
    public const int CARD_TYPE_DEBIT = 2;
    public const int TMP_PAYMENT_TRANS_TYPE_DEPOSIT = 2;
    public const int SOURCE_ADMIN = 1;
    public const int SOURCE_FINFLOW = 2;
    public const int SOURCE_MANUAL = 3;
    public const int SOURCE_AUTOMATION = 4;
}

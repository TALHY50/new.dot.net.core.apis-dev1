using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Send
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public int ReceiveId { get; set; }

    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserGsmNumber { get; set; }

    public int ToId { get; set; }

    public string? ToName { get; set; }

    public string? ToGsmNumber { get; set; }

    public int? ReceiverMerchantId { get; set; }

    public string? ReceiverMerchantName { get; set; }

    public int TransactionStateId { get; set; }

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public double? Cost { get; set; }

    public string? Description { get; set; }

    public string? Iban { get; set; }

    public string? BankName { get; set; }

    public int? BankStaticId { get; set; }

    public string? JsonData { get; set; }

    public double WithdrawableAmount { get; set; }

    public double NonWithdrawableAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? AdminProcessDate { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    /// <summary>
    /// 1 -&gt; send money 2 -&gt; B2B Payment 3-&gt; B2C Payment 4 -&gt; to_non_supay 5 -&gt; to_banks 6 -&gt; C2B payment 7 -&gt; Request Money, 8 -&gt; B2U Payment, 9 -&gt; C2C Cashout To Bank, 10 -&gt; Send Money To Walletgate, 11 -&gt; Reverted Split Account Send Money
    /// </summary>
    public sbyte? SendType { get; set; }

    public string? UniqueId { get; set; }

    public string? UniqueString { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }

    public const int SENDMONEY = 1;
    public const int  B2BPAYMENT = 2;
    public const int  B2CPAYMENT = 3;
    public const int  SENDMONEYTONONSIPAY = 4;
    public const int  SENDMONEYTOBANK = 5;
    public const int  SENDMONEYTOMERCHANT = 6;
    public const int  REQUESTMONEY = 7;
    public const int  B2UPAYMENT = 8;
    public const int  C2CCASHOUTTOBANK = 9;
    public const int  SENDMONEYTOWALLETGATE = 10;
    public const int  REVERTEDSPLITACCOUNTSENDMONEY = 11;
    public const int  TRANSMETHOD_PHONE = 1;
    public const int  TRANSMETHOD_CUSTOMER_NUMBER = 2;
    public const int  TRANSMETHOD_IBAN = 3;
}

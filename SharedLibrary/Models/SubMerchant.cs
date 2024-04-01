using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SubMerchant
{
    public int Id { get; set; }

    public string MerchantKey { get; set; } = null!;

    public int MerchantId { get; set; }

    public string SubMerchantId { get; set; } = null!;

    public string? TerminalNo { get; set; }

    public int UserId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? IdTcKn { get; set; }

    public string MerchantName { get; set; } = null!;

    public string FullCompanyName { get; set; } = null!;

    public string AuthorizedPersonName { get; set; } = null!;

    public string MerchantDescription { get; set; } = null!;

    public string PaymentReceiveOptions { get; set; } = null!;

    public string AuthorizedPersonPhoneNumber { get; set; } = null!;

    public string ContactPersonPhone { get; set; } = null!;

    public string AuthorizedPersonEmail { get; set; } = null!;

    public string MerchantType { get; set; } = null!;

    public string BusinessArea { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string IbanNo { get; set; } = null!;

    public sbyte IsEnableAutoWithdrawal { get; set; }

    /// <summary>
    /// Settlement ID for the Submerchant 
    /// </summary>
    public int? SettlementId { get; set; }

    /// <summary>
    /// In case merchant fails to aprove an item for settlement via TransactionApprove API after this number of days item will be auto approved for settlement
    ///  Values: -1 : Only Allowed if transaction is approved via TransactionApprove API
    /// 0 : Immediately Approved
    /// &gt;0 : Approved after this amount of days
    /// </summary>
    public short? AutoApprovalDays { get; set; }

    /// <summary>
    /// unique counter for sariTaxi submerchants to unique merchant_id and terminal_no . Default will be 0 for other type submerchants
    /// </summary>
    public int? MerchantTerminalUniqueCounter { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

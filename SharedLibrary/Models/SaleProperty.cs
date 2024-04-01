using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleProperty
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int MerchantId { get; set; }

    public string OrderId { get; set; } = null!;

    public int? CurrencyId { get; set; }

    public int SaleTransactionStateId { get; set; }

    public double Gross { get; set; }

    public uint CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string? CardCountryCode { get; set; }

    /// <summary>
    /// INSUFFICIENT_FUNDS = 51, LOST_CARD = 41, STOLEN_CARD = 43, HOLD_CARD = 07, EXPIRED_CARD = 54, DECLINED_CVV = 82
    /// </summary>
    public string? ErrorCode { get; set; }

    public string? Ip { get; set; }

    public string? CardNo { get; set; }

    public sbyte? PaymentSource { get; set; }

    /// <summary>
    /// 1=&gt;credit card, 2=&gt; mobile, 3=&gt;wallet, 4=&gt;All
    /// </summary>
    public sbyte PaymentTypeId { get; set; }

    public sbyte? IsProcessed { get; set; }

    public double? PreAuthAmount { get; set; }

    public string? MerchantServerId { get; set; }

    public string? RefererUrl { get; set; }

    /// <summary>
    /// 1=credit card, 2= debit card
    /// </summary>
    public sbyte? CardType { get; set; }

    public int? BankInstallmentNumber { get; set; }

    /// <summary>
    /// plus installment for pos campaign
    /// </summary>
    public sbyte? PlusInstallment { get; set; }

    /// <summary>
    /// &apos;7&apos; =&gt; &apos;Any&apos;, &apos;1&apos; =&gt; &apos;Visa&apos;, &apos;2&apos; =&gt; &apos;Master Card&apos;, &apos;3&apos; =&gt; &apos;Amex&apos;, &apos;4&apos; =&gt; &apos;Diners&apos;, &apos;5&apos; =&gt; &apos;Discover&apos;, &apos;6&apos; =&gt; &apos;JCB&apos;
    /// </summary>
    public sbyte? CardBrand { get; set; }

    public string? CardInfo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public sbyte? MigrationStatus { get; set; }

    public string? Mcc { get; set; }

    /// <summary>
    /// Description of the transaction if exists.
    /// </summary>
    public string? Description { get; set; }
}

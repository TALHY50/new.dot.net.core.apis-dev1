using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PaidBill
{
    public int Id { get; set; }

    public string? PaymentId { get; set; }

    public string? InvoiceId { get; set; }

    public string? OrderId { get; set; }

    public string? Name { get; set; }

    public string? Tckn { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? SubscriberNo { get; set; }

    public int? GroupId { get; set; }

    public string? GroupName { get; set; }

    public string? AssociationCode { get; set; }

    public string? AssociationName { get; set; }

    public string? BillInvoiceNumber { get; set; }

    public sbyte? PaymentMethod { get; set; }

    /// <summary>
    /// Bill Payment provider = Paycell,Intertech
    /// </summary>
    public string? BillPaymentProvider { get; set; }

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public sbyte? CurrencyId { get; set; }

    public string? InvoiceRefNo { get; set; }

    public string? InvoiceSeqNo { get; set; }

    public string? InvoiceStatus { get; set; }

    public string? InvoiceDueDate { get; set; }

    public double? InvoiceAmount { get; set; }

    public double? PaymentAmount { get; set; }

    public int? InvoiceIndex { get; set; }

    public double? CommissionAmount { get; set; }

    public double? TotalAmount { get; set; }

    public string? CustomPaymentMethod { get; set; }

    public string? PaymentOperation { get; set; }

    /// <summary>
    /// Transaction id from bill payment api response
    /// </summary>
    public string? RemoteTransactionId { get; set; }

    /// <summary>
    /// Transaction date from bill payment api response
    /// </summary>
    public DateTime? RemoteCreatedAt { get; set; }

    public string? CardHolder { get; set; }

    public string? CardNumber { get; set; }

    /// <summary>
    /// 0=&gt;pending, 1=&gt;approved, 2=&gt;rejected
    /// </summary>
    public sbyte? Status { get; set; }

    public int? MerchantId { get; set; }

    public string? MerchantName { get; set; }

    public int? UserId { get; set; }

    public string? UserName { get; set; }

    /// <summary>
    /// end user commission percentage for bill payment 
    /// </summary>
    public double? EndUserCommissionPercentage { get; set; }

    /// <summary>
    /// end user commission fixed for bill payment 
    /// </summary>
    public double? EndUserCommissionFixed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

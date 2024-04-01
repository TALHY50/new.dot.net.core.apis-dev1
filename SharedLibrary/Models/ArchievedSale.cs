using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ArchievedSale
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public string? InvoiceId { get; set; }

    public string? OrderId { get; set; }

    public string? RemoteOrderId { get; set; }

    /// <summary>
    /// host_refernce_id from provider response
    /// </summary>
    public string? HostReferenceId { get; set; }

    public int UserId { get; set; }

    public int? EndUserId { get; set; }

    public string? UserName { get; set; }

    public int MerchantId { get; set; }

    public string? MerchantName { get; set; }

    public int TransactionStateId { get; set; }

    public int PurchaseId { get; set; }

    public double Gross { get; set; }

    public double RefundRequestAmount { get; set; }

    public double Fee { get; set; }

    public double Net { get; set; }

    /// <summary>
    /// this amount will be calculated from the percentage and fixed on merchant commission tab
    /// </summary>
    public double PayByTokenFee { get; set; }

    public double Cost { get; set; }

    public double RollingAmount { get; set; }

    public double ProductPrice { get; set; }

    public double UserCommission { get; set; }

    public double MerchantCommission { get; set; }

    public string? GsmNumber { get; set; }

    public DateTime? SettlementDateBank { get; set; }

    public DateTime? SettlementDateMerchant { get; set; }

    /// <summary>
    /// 1=&gt;credit card, 2=&gt; mobile, 3=&gt;wallet, 4=&gt;depositEFT
    /// </summary>
    public sbyte? PaymentTypeId { get; set; }

    public string? Operator { get; set; }

    public string? IssuerName { get; set; }

    public string? CardIssuerName { get; set; }

    public string? CardProgram { get; set; }

    public string? PosName { get; set; }

    public int? PosId { get; set; }

    public int? AllocationId { get; set; }

    public int? CampaignId { get; set; }

    public int? DplId { get; set; }

    public string? JsonData { get; set; }

    public string? Document { get; set; }

    public double? TotalRefundedAmount { get; set; }

    public string? RefundReason { get; set; }

    public DateTime? RefundRequestDate { get; set; }

    public DateTime? AdminProcessDate { get; set; }

    public string? ChargebackRejectExplanation { get; set; }

    /// <summary>
    /// If duplicate invoice allowed merchant comes with duplicate invoice we will update all the sales with same invoice_id and merchant_id with 1.
    /// 0 = No Duplicate
    /// 1 = Found Duplicate
    /// 2 = Cacnelled In Bank
    /// 3 = Tmp Refund Request Created
    /// 
    /// </summary>
    public sbyte? IsDuplicateInvoice { get; set; }

    /// <summary>
    /// To determine if sale settlement is installment wise
    /// </summary>
    public bool? IsInstallmentWiseSettlement { get; set; }

    /// <summary>
    /// This is the source to know the initiator of completePayment (2nd step) of a payment model
    /// Complete Payment By
    /// 1 = App
    /// 2 = Merchant
    /// 
    /// </summary>
    public sbyte? PaymentCompletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? Installment { get; set; }

    public int? MaturityPeriod { get; set; }

    public int? PaymentFrequency { get; set; }

    public string? Ip { get; set; }

    /// <summary>
    /// mdStatus from bank response ranges from 0-9
    /// 0: Card verification failed, do not proceed
    /// 1: Verification successful, you can continue with the transaction
    /// 2: Card holder or bank is not registered in the system
    /// 3: The bank of the card is not registered in the system
    /// 4: Verification attempt, cardholder has chosen to register with the system
    /// later
    /// 5: Unable to verify
    /// 6: 3-D Secure error
    /// 7: System error
    /// 8: Unknown card no
    /// 9: Member Merchant not registered to 3D-Secure system (merchant or
    /// terminal number is not registered on the back as 3d) 
    /// </summary>
    public sbyte? MdStatus { get; set; }

    public string? Result { get; set; }

    public string? CreditCardNo { get; set; }

    public string? CardHolderBank { get; set; }

    public sbyte? SaleVersion { get; set; }

    /// <summary>
    /// 1=3D branding and paid by CC, 2= 2D branding and paid by CC, 3 = Mobile payment, 4 = wallet payment, 5 = white label 3D, 6=whiite label 2D, 7 = Redirected white label 3D, 8 = Redirected white label 2D, 9 = DPL 3d, 10 = DPL 2d
    /// </summary>
    public sbyte PaymentSource { get; set; }

    public double? RefundedChargebackFee { get; set; }

    /// <summary>
    /// 0 = not tried yet or pass, 1 = tried and failed
    /// </summary>
    public sbyte? IsBankRefundFailed { get; set; }

    /// <summary>
    /// 1=auth , 2=PreAuth
    /// </summary>
    public sbyte? SaleType { get; set; }

    /// <summary>
    /// 0 = Sale, 1 = Recurring, 2 = DPL
    /// </summary>
    public int? RecurringId { get; set; }

    public string? SaleWebHookKey { get; set; }

    public string? AuthCode { get; set; }

    public sbyte? MigrationStatus { get; set; }

    /// <summary>
    /// 0 =&gt; exiting flow
    /// 1 =&gt; new calculation with user fee brutally change
    /// 2 =&gt; new calculation with user fee brutally change as zero
    /// </summary>
    public sbyte IsComissionFromUser { get; set; }

    public string? CommissionForInstallment { get; set; }

    public DateTime? RemoteTransactionDatetime { get; set; }

    /// <summary>
    /// 0 =&gt; with cvv
    /// 1 =&gt; without cvv
    /// </summary>
    public sbyte IsCvvLess { get; set; }

    /// <summary>
    /// force chargeback document
    /// </summary>
    public string? AdminForceChargebackDocument { get; set; }

    /// <summary>
    /// force chargeback reason
    /// </summary>
    public string? AdminForceChargebackExplanation { get; set; }

    public int? CreatedAtInt { get; set; }

    public int? UpdatedAtInt { get; set; }
}
